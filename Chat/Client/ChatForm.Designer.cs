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
            this.label1 = new System.Windows.Forms.Label();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.signInButton = new System.Windows.Forms.Button();
            this.signOutButton = new System.Windows.Forms.Button();
            this.chatHistory = new System.Windows.Forms.TextBox();
            this.usersList = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите имя/ник:";
            // 
            // userNameBox
            // 
            this.userNameBox.BackColor = System.Drawing.SystemColors.Window;
            this.userNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.userNameBox.Location = new System.Drawing.Point(141, 14);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(291, 23);
            this.userNameBox.TabIndex = 1;
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(438, 12);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(114, 27);
            this.signInButton.TabIndex = 2;
            this.signInButton.Text = "Войти";
            this.signInButton.UseVisualStyleBackColor = true;
            // 
            // signOutButton
            // 
            this.signOutButton.Location = new System.Drawing.Point(558, 12);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(114, 27);
            this.signOutButton.TabIndex = 3;
            this.signOutButton.Text = "Выйти";
            this.signOutButton.UseVisualStyleBackColor = true;
            // 
            // chatHistory
            // 
            this.chatHistory.BackColor = System.Drawing.Color.White;
            this.chatHistory.Location = new System.Drawing.Point(12, 43);
            this.chatHistory.Multiline = true;
            this.chatHistory.Name = "chatHistory";
            this.chatHistory.ReadOnly = true;
            this.chatHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatHistory.Size = new System.Drawing.Size(420, 368);
            this.chatHistory.TabIndex = 4;
            // 
            // usersList
            // 
            this.usersList.BackColor = System.Drawing.Color.White;
            this.usersList.Location = new System.Drawing.Point(438, 65);
            this.usersList.Multiline = true;
            this.usersList.Name = "usersList";
            this.usersList.ReadOnly = true;
            this.usersList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.usersList.Size = new System.Drawing.Size(234, 346);
            this.usersList.TabIndex = 5;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(12, 417);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageBox.Size = new System.Drawing.Size(540, 61);
            this.messageBox.TabIndex = 6;
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.sendButton.Location = new System.Drawing.Point(558, 417);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(114, 61);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(438, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Пользователи онлайн:";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(684, 479);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.usersList);
            this.Controls.Add(this.chatHistory);
            this.Controls.Add(this.signOutButton);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.label1);
            this.Name = "ChatForm";
            this.Text = "Чат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Button signOutButton;
        private System.Windows.Forms.TextBox chatHistory;
        private System.Windows.Forms.TextBox usersList;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label2;
    }
}

