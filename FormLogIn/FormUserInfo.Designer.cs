﻿
namespace FormLogIn
{
    partial class FormUserInfo
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
            textBox_Username = new TextBox();
            textBox_Email = new TextBox();
            button_Close = new Button();
            SuspendLayout();
            // 
            // textBox_Username
            // 
            textBox_Username.BackColor = SystemColors.MenuText;
            textBox_Username.BorderStyle = BorderStyle.None;
            textBox_Username.ForeColor = SystemColors.Window;
            textBox_Username.Location = new Point(519, 269);
            textBox_Username.Name = "textBox_Username";
            textBox_Username.ReadOnly = true;
            textBox_Username.Size = new Size(236, 20);
            textBox_Username.TabIndex = 1;
            textBox_Username.TextChanged += textBox_Username_TextChanged;
            // 
            // textBox_Email
            // 
            textBox_Email.BackColor = SystemColors.MenuText;
            textBox_Email.BorderStyle = BorderStyle.None;
            textBox_Email.ForeColor = SystemColors.Window;
            textBox_Email.Location = new Point(519, 358);
            textBox_Email.Name = "textBox_Email";
            textBox_Email.ReadOnly = true;
            textBox_Email.Size = new Size(236, 20);
            textBox_Email.TabIndex = 3;
            textBox_Email.TextChanged += textBox_Email_TextChanged;
            // 
            // button_Close
            // 
            button_Close.Location = new Point(559, 440);
            button_Close.Name = "button_Close";
            button_Close.Size = new Size(171, 52);
            button_Close.TabIndex = 6;
            button_Close.Text = "Sign out";
            button_Close.UseVisualStyleBackColor = true;
            button_Close.Click += button_Close_Click;
            // 
            // FormUserInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._3;
            ClientSize = new Size(1296, 577);
            Controls.Add(button_Close);
            Controls.Add(textBox_Email);
            Controls.Add(textBox_Username);
            Name = "FormUserInfo";
            Text = "UserInfo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox_Username;
        private TextBox textBox_Email;
        private Button button_Close;
    }
}