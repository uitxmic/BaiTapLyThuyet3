
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserInfo));
            textBox_Username = new TextBox();
            textBox_Email = new TextBox();
            button_Close = new Button();
            textBox_Birthday = new TextBox();
            textBox_Fullname = new TextBox();
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
            // 
            // textBox_Email
            // 
            textBox_Email.BackColor = SystemColors.MenuText;
            textBox_Email.BorderStyle = BorderStyle.None;
            textBox_Email.ForeColor = SystemColors.Window;
            textBox_Email.Location = new Point(519, 525);
            textBox_Email.Name = "textBox_Email";
            textBox_Email.ReadOnly = true;
            textBox_Email.Size = new Size(236, 20);
            textBox_Email.TabIndex = 3;
            // 
            // button_Close
            // 
            button_Close.Location = new Point(547, 577);
            button_Close.Name = "button_Close";
            button_Close.Size = new Size(171, 52);
            button_Close.TabIndex = 6;
            button_Close.Text = "Sign out";
            button_Close.UseVisualStyleBackColor = true;
            button_Close.Click += button_Close_Click;
            // 
            // textBox_Birthday
            // 
            textBox_Birthday.BackColor = SystemColors.MenuText;
            textBox_Birthday.BorderStyle = BorderStyle.None;
            textBox_Birthday.ForeColor = SystemColors.Window;
            textBox_Birthday.Location = new Point(519, 435);
            textBox_Birthday.Name = "textBox_Birthday";
            textBox_Birthday.ReadOnly = true;
            textBox_Birthday.Size = new Size(236, 20);
            textBox_Birthday.TabIndex = 7;
            // 
            // textBox_Fullname
            // 
            textBox_Fullname.BackColor = SystemColors.MenuText;
            textBox_Fullname.BorderStyle = BorderStyle.None;
            textBox_Fullname.ForeColor = SystemColors.Window;
            textBox_Fullname.Location = new Point(519, 359);
            textBox_Fullname.Name = "textBox_Fullname";
            textBox_Fullname.ReadOnly = true;
            textBox_Fullname.Size = new Size(236, 20);
            textBox_Fullname.TabIndex = 8;
            // 
            // FormUserInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1296, 660);
            Controls.Add(textBox_Fullname);
            Controls.Add(textBox_Birthday);
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
        private TextBox textBox_Birthday;
        private TextBox textBox_Fullname;
    }
}