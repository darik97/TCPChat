namespace Client
{
    partial class ChatForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.label1 = new System.Windows.Forms.Label();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.signInButton = new System.Windows.Forms.Button();
            this.signOutButton = new System.Windows.Forms.Button();
            this.chatHistory = new System.Windows.Forms.RichTextBox();
            this.usersList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.imgBox = new System.Windows.Forms.ListView();
            this.host = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "имя/ник:";
            // 
            // userNameBox
            // 
            this.userNameBox.BackColor = System.Drawing.SystemColors.Window;
            this.userNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.userNameBox.Location = new System.Drawing.Point(82, 14);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(177, 23);
            this.userNameBox.TabIndex = 1;
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(557, 12);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(71, 27);
            this.signInButton.TabIndex = 2;
            this.signInButton.Text = "Войти";
            this.signInButton.UseVisualStyleBackColor = true;
            // 
            // signOutButton
            // 
            this.signOutButton.Location = new System.Drawing.Point(634, 12);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(67, 27);
            this.signOutButton.TabIndex = 3;
            this.signOutButton.Text = "Выйти";
            this.signOutButton.UseVisualStyleBackColor = true;
            // 
            // chatHistory
            // 
            this.chatHistory.BackColor = System.Drawing.Color.White;
            this.chatHistory.Location = new System.Drawing.Point(173, 45);
            this.chatHistory.Name = "chatHistory";
            this.chatHistory.ReadOnly = true;
            this.chatHistory.Size = new System.Drawing.Size(379, 368);
            this.chatHistory.TabIndex = 4;
            this.chatHistory.Text = "";
            // 
            // usersList
            // 
            this.usersList.BackColor = System.Drawing.Color.White;
            this.usersList.Location = new System.Drawing.Point(12, 65);
            this.usersList.Multiline = true;
            this.usersList.Name = "usersList";
            this.usersList.ReadOnly = true;
            this.usersList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.usersList.Size = new System.Drawing.Size(155, 346);
            this.usersList.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Пользователи онлайн:";
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(12, 417);
            this.messageBox.MaximumSize = new System.Drawing.Size(540, 72);
            this.messageBox.MinimumSize = new System.Drawing.Size(540, 24);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(540, 50);
            this.messageBox.TabIndex = 9;
            this.messageBox.Text = "";
            // 
            // imgBox
            // 
            this.imgBox.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.imgBox.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.imgBox.CausesValidation = false;
            this.imgBox.Location = new System.Drawing.Point(557, 45);
            this.imgBox.MultiSelect = false;
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(144, 366);
            this.imgBox.TabIndex = 10;
            this.imgBox.UseCompatibleStateImageBehavior = false;
            // 
            // host
            // 
            this.host.Location = new System.Drawing.Point(357, 14);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(194, 20);
            this.host.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Адрес сервера:";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "s0.png");
            this.imageList.Images.SetKeyName(1, "s1.png");
            this.imageList.Images.SetKeyName(2, "s2.png");
            this.imageList.Images.SetKeyName(3, "s3.png");
            this.imageList.Images.SetKeyName(4, "s4.png");
            this.imageList.Images.SetKeyName(5, "s5.png");
            this.imageList.Images.SetKeyName(6, "s6.png");
            this.imageList.Images.SetKeyName(7, "s7.png");
            this.imageList.Images.SetKeyName(8, "s8.png");
            this.imageList.Images.SetKeyName(9, "s9.png");
            this.imageList.Images.SetKeyName(10, "s10.png");
            this.imageList.Images.SetKeyName(11, "s11.png");
            this.imageList.Images.SetKeyName(12, "s12.png");
            this.imageList.Images.SetKeyName(13, "s13.png");
            this.imageList.Images.SetKeyName(14, "s14.png");
            this.imageList.Images.SetKeyName(15, "s15.png");
            this.imageList.Images.SetKeyName(16, "s16.png");
            this.imageList.Images.SetKeyName(17, "s17.png");
            this.imageList.Images.SetKeyName(18, "s18.png");
            this.imageList.Images.SetKeyName(19, "s19.png");
            this.imageList.Images.SetKeyName(20, "s20.png");
            this.imageList.Images.SetKeyName(21, "s21.png");
            this.imageList.Images.SetKeyName(22, "s22.png");
            this.imageList.Images.SetKeyName(23, "s23.png");
            this.imageList.Images.SetKeyName(24, "s24.png");
            this.imageList.Images.SetKeyName(25, "s25.png");
            this.imageList.Images.SetKeyName(26, "s26.png");
            this.imageList.Images.SetKeyName(27, "s27.png");
            this.imageList.Images.SetKeyName(28, "s28.png");
            this.imageList.Images.SetKeyName(29, "s29.png");
            this.imageList.Images.SetKeyName(30, "s30.png");
            this.imageList.Images.SetKeyName(31, "s31.png");
            this.imageList.Images.SetKeyName(32, "s32.png");
            this.imageList.Images.SetKeyName(33, "s33.png");
            this.imageList.Images.SetKeyName(34, "s34.png");
            this.imageList.Images.SetKeyName(35, "s35.png");
            this.imageList.Images.SetKeyName(36, "s36.png");
            this.imageList.Images.SetKeyName(37, "s37.png");
            this.imageList.Images.SetKeyName(38, "s38.png");
            this.imageList.Images.SetKeyName(39, "s39.png");
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sendButton.Location = new System.Drawing.Point(558, 417);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(143, 50);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(703, 479);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.host);
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.usersList);
            this.Controls.Add(this.chatHistory);
            this.Controls.Add(this.signOutButton);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Button signOutButton;
        private System.Windows.Forms.RichTextBox chatHistory;
        private System.Windows.Forms.TextBox usersList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.ListView imgBox;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button sendButton;
    }
}

