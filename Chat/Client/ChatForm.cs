using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatForm : Form
    {
        static string userName;
        private const string host = "127.0.0.1";
        private const int port = 8000;
        static TcpClient client;
        static NetworkStream stream;

        public ChatForm()
        {
            InitializeComponent();

            userNameBox.Focus();
            signInButton.Enabled = true;
            signOutButton.Enabled = false;
            chatHistory.Enabled = false;
            messageBox.Enabled = false;
            sendButton.Enabled = false;

            signInButton.Click += SignInButton_Click;
            userNameBox.KeyUp += (sender, arg) =>
            {
                if (arg.KeyCode == Keys.Enter)
                {
                    SignInButton_Click(sender, arg);
                }
            };

            sendButton.Click += SendButton_Click;
            messageBox.KeyDown += (sender, arg) =>
            {
                if (arg.KeyCode == Keys.Enter)
                {
                    SendButton_Click(sender, arg);
                }
            };

            signOutButton.Click += (sender, arg) => disconnect();
            FormClosing += (sender, arg) => disconnect();
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            if (userNameBox.Text != "")
            {
                userName = userNameBox.Text;

                userNameBox.Enabled = false;
                signInButton.Enabled = false;
                signOutButton.Enabled = true;
                chatHistory.Enabled = true;
                chatHistory.ReadOnly = true;
                
                messageBox.Enabled = true;
                sendButton.Enabled = true;
                messageBox.Focus();

                client = new TcpClient();
                startChat();
            }
            else
            {
                MessageBox.Show("Введите имя!");
            }
        }

        private void startChat()
        {
            try
            {
                client.Connect(host, port);
                stream = client.GetStream();

                string message = userName;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                Thread receiveThread = new Thread(new ThreadStart(receiveMessage));
                receiveThread.Start();

                chatHistory.Text = "Добро пожаловать, " + userName + "\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при подключении");
            }
        }

        private void receiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[512];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    List<string> messageList = new List<string>();
                    if (isUsersList(message, out messageList))
                    {
                        usersList.Text = "";
                        message = messageList[0];
                        for (int i = 1; i < messageList.Count; i++)
                        {
                            usersList.Text += messageList[i] + "\r\n";
                        }
                    }

                    chatHistory.Text += "\r\n" + message;
                    chatHistory.Select(chatHistory.Text.Length, 0);
                    chatHistory.ScrollToCaret();
                }
                catch
                {
                    MessageBox.Show("Подключение прервано!");
                    disconnect();
                }
            }
        }

        private bool isUsersList(string message, out List<string> list)
        {
            list = null;

            string temp = message;
            Regex regex = new Regex("[0-2][0-9]:[0-6][0-9] ");
            MatchCollection matches = regex.Matches(temp);
            if (matches.Count == 0)
            {
                String[] substrings = temp.Split(';');
                list = substrings.ToList();
                return true;   
            }
            return false;  
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (messageBox.Text != "")
            {
                string message = messageBox.Text;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
                messageBox.Focus();
                messageBox.Clear();
            }
        }

        private void disconnect()
        {
            if (stream != null)
            {
                stream.Close();
            }
            if (client != null)
            {
                client.Close();
            }
            Environment.Exit(0);
        }
    }
}
