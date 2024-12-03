
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
            textBox_Birthday = new TextBox();
            textBox_Fullname = new TextBox();
            btnList = new Button();
            btnChangePassword = new Button();
            btnSignout = new Button();
            btnBacktoBookSearch = new Button();
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
            // btnList
            // 
            btnList.Location = new Point(1148, 612);
            btnList.Name = "btnList";
            btnList.Size = new Size(136, 36);
            btnList.TabIndex = 9;
            btnList.Text = "List bookshelves";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(1000, 612);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(142, 36);
            btnChangePassword.TabIndex = 10;
            btnChangePassword.Text = "ChangePassword";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnSignout
            // 
            btnSignout.Location = new Point(601, 588);
            btnSignout.Name = "btnSignout";
            btnSignout.Size = new Size(84, 29);
            btnSignout.TabIndex = 11;
            btnSignout.Text = "Sign Out";
            btnSignout.UseVisualStyleBackColor = true;
            btnSignout.Click += btnSignout_Click_1;
            // 
            // btnBacktoBookSearch
            // 
            btnBacktoBookSearch.Location = new Point(12, 619);
            btnBacktoBookSearch.Name = "btnBacktoBookSearch";
            btnBacktoBookSearch.Size = new Size(94, 29);
            btnBacktoBookSearch.TabIndex = 12;
            btnBacktoBookSearch.Text = "Back";
            btnBacktoBookSearch.UseVisualStyleBackColor = true;
            btnBacktoBookSearch.Click += btnBacktoBookSearch_Click;
            // 
            // FormUserInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1296, 660);
            Controls.Add(btnBacktoBookSearch);
            Controls.Add(btnSignout);
            Controls.Add(btnChangePassword);
            Controls.Add(btnList);
            Controls.Add(textBox_Fullname);
            Controls.Add(textBox_Birthday);
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
        private TextBox textBox_Birthday;
        private TextBox textBox_Fullname;
        private Button btnList;
        private Button btnChangePassword;
        private Button btnSignout;
        private Button btnBacktoBookSearch;
    }
}