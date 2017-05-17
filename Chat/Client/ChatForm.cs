using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatForm : Form
    {
        public string UserName { get; private set; }

        public delegate void UpdateUsersList(List<string> userList);
        public UpdateUsersList UsersDelegate;

        public delegate void UpdateChatHistory(string newMessage);
        public UpdateChatHistory ChatDelegate;

        public delegate void ShowErrorMessage(string error, string header);
        public ShowErrorMessage ErrorDelegate;

        ChatController chatController;

        public ChatForm()
        {
            InitializeComponent();

            userNameBox.Focus();
            signInButton.Enabled = true;
            signOutButton.Enabled = false;
            chatHistory.Enabled = false;
            messageBox.Enabled = false;
            sendButton.Enabled = false;

            signInButton.Click += signInButton_Click;
            userNameBox.KeyUp += (sender, arg) =>
            {
                if (arg.KeyCode == Keys.Enter)
                {
                    signInButton_Click(sender, arg);
                }
            };

            sendButton.Click += sendButton_Click;
            messageBox.KeyDown += (sender, arg) =>
            {
                if (arg.KeyCode == Keys.Enter)
                {
                    sendButton_Click(sender, arg);
                }
            };

            signOutButton.Click += (sender, arg) => chatController.Disconnect();
            FormClosing += (sender, arg) => chatController.Disconnect();

            UsersDelegate = new UpdateUsersList(printUsers);
            ChatDelegate = new UpdateChatHistory(printMessage);
            ErrorDelegate = new ShowErrorMessage(showError);

            chatController = new ChatController(this);
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (userNameBox.Text != "")
            {
                UserName = userNameBox.Text;

                userNameBox.Enabled = false;
                signInButton.Enabled = false;
                signOutButton.Enabled = true;
                chatHistory.Enabled = true;
                chatHistory.ReadOnly = true;

                messageBox.Enabled = true;
                sendButton.Enabled = true;
                messageBox.Focus();

                chatController.StartChat(new TcpClient());
            }
            else
            {
                showError("Введите имя!", "Вход запрещен");
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (messageBox.Text != "")
            {
                string message = messageBox.Text;
                chatController.SendMessage(message);
                messageBox.Focus();
                messageBox.Clear();
            }
        }

        private void printMessage(string message)
        {
            chatHistory.Text += message + "\r\n";
            chatHistory.Select(chatHistory.Text.Length, 0);
            chatHistory.ScrollToCaret();
        }

        private void printUsers(List<string> messageList)
        {
            usersList.Clear();
            for (int i = 1; i < messageList.Count; i++)
            {
                usersList.Text += messageList[i] + "\r\n";
            }
        }

        private void showError(string error, string header)
        {
            MessageBox.Show(error, header);
        }

    }
}
