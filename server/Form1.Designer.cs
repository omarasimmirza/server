namespace server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IF_logs = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SPS_logs = new System.Windows.Forms.RichTextBox();
            this.User_logs = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(71, 28);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(250, 29);
            this.textBox_port.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(341, 23);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(102, 41);
            this.button_listen.TabIndex = 2;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(17, 168);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(426, 668);
            this.logs.TabIndex = 3;
            this.logs.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(597, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "IF100:";
            // 
            // IF_logs
            // 
            this.IF_logs.Location = new System.Drawing.Point(602, 60);
            this.IF_logs.Name = "IF_logs";
            this.IF_logs.Size = new System.Drawing.Size(451, 238);
            this.IF_logs.TabIndex = 8;
            this.IF_logs.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(597, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "SPS101:";
            // 
            // SPS_logs
            // 
            this.SPS_logs.Location = new System.Drawing.Point(602, 329);
            this.SPS_logs.Name = "SPS_logs";
            this.SPS_logs.Size = new System.Drawing.Size(451, 238);
            this.SPS_logs.TabIndex = 10;
            this.SPS_logs.Text = "";
            // 
            // User_logs
            // 
            this.User_logs.Location = new System.Drawing.Point(602, 598);
            this.User_logs.Name = "User_logs";
            this.User_logs.Size = new System.Drawing.Size(451, 238);
            this.User_logs.TabIndex = 11;
            this.User_logs.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(597, 570);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Users:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Logs:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 861);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.User_logs);
            this.Controls.Add(this.SPS_logs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IF_logs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_port);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox IF_logs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox SPS_logs;
        private System.Windows.Forms.RichTextBox User_logs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}

