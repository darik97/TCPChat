using Client.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
namespace Client
{
    public partial class ChatForm : Form
    {
        public string UserName { get; private set; }
        public string Host { get; private set; }
        private IPAddress hostIP;

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

            imgBox.LargeImageList = imageList;
            

            signInButton.Click += signInButton_Click;
            userNameBox.KeyUp += (sender, arg) =>
            {
                if (arg.KeyCode == Keys.Enter && IPAddress.TryParse(host.Text, out hostIP) 
                && host.Text.Trim().Count(c => c == '.') == 3)
                {
                    signInButton_Click(sender, arg);
                }
            };

            host.KeyUp += (sender, arg) =>
            {
                if (arg.KeyCode == Keys.Enter && IPAddress.TryParse(host.Text, out hostIP) 
                && host.Text.Trim().Count(c => c == '.') == 3)
                {
                    signInButton_Click(sender, arg);
                }
            };

            sendButton.Click += sendButton_Click;
            messageBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    sendButton_Click(s, e);
                }
            };

            signOutButton.Click += (sender, arg) => chatController.Disconnect();
            FormClosing += (sender, arg) => chatController.Disconnect();

            UsersDelegate = new UpdateUsersList(printUsers);
            ChatDelegate = new UpdateChatHistory(printMessage);
            ErrorDelegate = new ShowErrorMessage(showError);

            chatController = new ChatController(this);

            imgBox.Click += (sender, e) => listView1_DoubleClick(sender, e);
            printImage(0);
        }


        public bool FindMyText(string text)
        {
            // Initialize the return value to false by default.
            bool returnValue = false;

            // Ensure a search string has been specified.
            if (text.Length > 0)
            {
                // Obtain the location of the search string in richTextBox1.
                int indexToText = chatHistory.Find(text);
                // Determine whether the text was found in richTextBox1.
                if (indexToText >= 0)
                {
                    returnValue = true;
                }
            }

            return returnValue;
        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in imgBox.SelectedItems)
            {
                int imgIndex = itm.ImageIndex;
                if (imgIndex >= 0 && imgIndex < this.imageList.Images.Count)
                {
                    MessageBox.Show(imgIndex.ToString());
                    var t = FindMyText("hi");
                    //printImage(imgIndex);
                }
            }
            imgBox.HideSelection = true;
        }

        void addImages()
        {
            for (int i = 0; i < 40; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;

                imgBox.Items.Add(lvi);
            }
        }

        private void sticker_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (userNameBox.Text != "" && IPAddress.TryParse(host.Text, out hostIP) 
                && host.Text.Trim().Count(c => c == '.') == 3)
            {
                UserName = userNameBox.Text;
                Host = host.Text;

                userNameBox.Enabled = false;
                signInButton.Enabled = false;
                signOutButton.Enabled = true;
                chatHistory.Enabled = true;
                chatHistory.ReadOnly = true;

                messageBox.Enabled = true;
                sendButton.Enabled = true;
                messageBox.Focus();

                chatController.StartChat(new TcpClient());
                addImages();
            }
            else
            {
                showError("Введите имя!", "Вход запрещен");
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (messageBox.Text.Trim() != "")
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

        private void printImage(int index)
        {
            Image img = Resources.s0;
            Clipboard.SetImage(img);
            chatHistory.Paste();
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
