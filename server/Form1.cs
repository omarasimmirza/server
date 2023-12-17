using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Client> connectedClients = new List<Client>();

        bool terminating = false;
        bool listening = false;
        private int multicastPort;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;

            foreach (Client client in connectedClients)
            {
                client.Socket.Close();
            }

            serverSocket.Close();

            Environment.Exit(0);
        }
        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox_port.Text, out serverPort))
            {
                this.multicastPort = serverPort;
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");
            }
            else
            {
                logs.AppendText("Please check port number \n");
            }
        }

        private IPAddress GetMulticastAddress(string channel)
        {
            // Use a simple hashing algorithm to generate a unique address based on the channel name
            int hash = channel.GetHashCode();
            byte[] addressBytes = new byte[4];
            BitConverter.GetBytes(hash).CopyTo(addressBytes, 0);
            addressBytes[0] = 224;  // Standard multicast address range

            return new IPAddress(addressBytes);
        }

        private int GetMulticastPort(string channel)
        {
            // Use a fixed port for all channels for this example
            return multicastPort;  // Choose a port number not conflicting with other applications
        }

        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    Client client = new Client(newClient);

                    Thread receiveThread = new Thread(() => Receive(client));
                    receiveThread.Start();

                    connectedClients.Add(client);
                    logs.AppendText("A client is connected. Username: " + client.Username + "\n");
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }
                }
            }
        }

        private void Receive(Client client)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    client.Socket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    ProcessMessage(client, incomingMessage);
                    connected = false;
                    if (!connected)
                    {
                        client.Socket.Close(); // Close socket before removing client
                        connectedClients.Remove(client);
                        logs.AppendText("Client " + client.Username + " disconnected.\n");
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("Client " + client.Username + " has disconnected.\n");
                    }

                    client.Socket.Close();
                    connectedClients.Remove(client);
                    connected = false;
                }
            }
        }

        private void SendToAllClients(string message)
        {
            foreach (Client client in connectedClients)
            {
                try
                {
                    byte[] data = Encoding.Default.GetBytes(message);
                    client.Socket.Send(data);
                }
                catch (Exception ex)
                {
                    logs.AppendText("Error sending message to client: " + ex.Message + "\n");
                    client.Socket.Close();
                    connectedClients.Remove(client);
                }
            }

            logs.AppendText("Server: " + message + "\n");
        }

        private void SendToChannel(string message, List<string> subscriptions)
        {
            foreach (Client client in connectedClients)
            {
                if (client.Subscriptions.Any(subscription => subscriptions.Contains(subscription)))
                {
                    try
                    {
                        byte[] data = Encoding.Default.GetBytes(message);
                        client.Socket.Send(data);
                    }
                    catch (Exception ex)
                    {
                        logs.AppendText("Error sending message to client: " + ex.Message + "\n");
                        client.Socket.Close();
                        connectedClients.Remove(client);
                    }
                }
            }
            logs.AppendText("Server: " + message + " (sent to channel)\n");
        }

        private void ProcessMessage(Client client, string message)
        {
            string[] parts = message.Split(':');
            string messageType = parts[0];
            string messageContent = parts[1];

            switch (messageType)
            {
                case "CONNECT":
                    client.Username = messageContent;
                    SendToAllClients(client.Username + " connected.\n");
                    break;
                case "SUBSCRIBE":
                    client.Subscriptions.Add(messageContent);
                    logs.AppendText("Client " + client.Username + " subscribed to channel " + messageContent + "\n");
                    break;
                case "UNSUBSCRIBE":
                    client.Subscriptions.Remove(messageContent);
                    logs.AppendText("Client " + client.Username + " unsubscribed from channel " + messageContent + "\n");
                    break;
                case "MESSAGE":
                    SendToChannel(messageContent, client.Subscriptions);
                    break;
                default:
                    logs.AppendText("Unknown message type: " + messageType + "\n");
                    break;
            }
        }
    }
}