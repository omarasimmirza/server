using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace server
{
    public class Client
    {
        public Socket Socket { get; private set; }
        public string Username { get; set; }
        public List<string> Subscriptions { get; set; }

        public Client(Socket socket)
        {
            Socket = socket;
            Username = "";
            Subscriptions = new List<string>();
        }
    }
}
