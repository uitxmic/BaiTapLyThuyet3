namespace FormLogIn
{
    partial class FormSignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSignUp));
            label_TieuDe2 = new Label();
            textBox_ConfirmPassword = new TextBox();
            textBox_Password = new TextBox();
            textBox_Name = new TextBox();
            textBox_Email = new TextBox();
            button_SignUp = new Button();
            button_Login = new Button();
            label1 = new Label();
            checkBox_Pass = new CheckBox();
            SuspendLayout();
            // 
            // label_TieuDe2
            // 
            label_TieuDe2.AutoSize = true;
            label_TieuDe2.BackColor = SystemColors.ActiveCaptionText;
            label_TieuDe2.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_TieuDe2.ForeColor = SystemColors.Window;
            label_TieuDe2.Location = new Point(672, 119);
            label_TieuDe2.Name = "label_TieuDe2";
            label_TieuDe2.Size = new Size(184, 28);
            label_TieuDe2.TabIndex = 1;
            label_TieuDe2.Text = "to continue with app";
            // 
            // textBox_ConfirmPassword
            // 
            textBox_ConfirmPassword.BackColor = SystemColors.MenuText;
            textBox_ConfirmPassword.BorderStyle = BorderStyle.None;
            textBox_ConfirmPassword.ForeColor = SystemColors.Window;
            textBox_ConfirmPassword.Location = new Point(515, 592);
            textBox_ConfirmPassword.Name = "textBox_ConfirmPassword";
            textBox_ConfirmPassword.PlaceholderText = "Confirm Password";
            textBox_ConfirmPassword.Size = new Size(248, 20);
            textBox_ConfirmPassword.TabIndex = 6;
            // 
            // textBox_Password
            // 
            textBox_Password.BackColor = SystemColors.MenuText;
            textBox_Password.BorderStyle = BorderStyle.None;
            textBox_Password.ForeColor = SystemColors.Window;
            textBox_Password.Location = new Point(515, 490);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.PlaceholderText = "Password";
            textBox_Password.Size = new Size(248, 20);
            textBox_Password.TabIndex = 7;
            // 
            // textBox_Name
            // 
            textBox_Name.BackColor = SystemColors.MenuText;
            textBox_Name.BorderStyle = BorderStyle.None;
            textBox_Name.ForeColor = SystemColors.Window;
            textBox_Name.Location = new Point(515, 309);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.PlaceholderText = "Username";
            textBox_Name.Size = new Size(248, 20);
            textBox_Name.TabIndex = 8;
            // 
            // textBox_Email
            // 
            textBox_Email.BackColor = SystemColors.MenuText;
            textBox_Email.BorderStyle = BorderStyle.None;
            textBox_Email.ForeColor = SystemColors.Window;
            textBox_Email.Location = new Point(515, 400);
            textBox_Email.Name = "textBox_Email";
            textBox_Email.PlaceholderText = "Your Email";
            textBox_Email.Size = new Size(248, 20);
            textBox_Email.TabIndex = 9;
            // 
            // button_SignUp
            // 
            button_SignUp.Location = new Point(552, 714);
            button_SignUp.Name = "button_SignUp";
            button_SignUp.Size = new Size(176, 45);
            button_SignUp.TabIndex = 10;
            button_SignUp.Text = "Sign Up";
            button_SignUp.UseVisualStyleBackColor = true;
            button_SignUp.Click += button_SignUp_Click;
            // 
            // button_Login
            // 
            button_Login.Location = new Point(552, 179);
            button_Login.Name = "button_Login";
            button_Login.Size = new Size(176, 51);
            button_Login.TabIndex = 11;
            button_Login.Text = "Login";
            button_Login.UseVisualStyleBackColor = true;
            button_Login.Click += button_Login_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(780, 445);
            label1.Name = "label1";
            label1.Size = new Size(150, 28);
            label1.TabIndex = 12;
            label1.Text = "Reveal Password";
            // 
            // checkBox_Pass
            // 
            checkBox_Pass.AutoSize = true;
            checkBox_Pass.BackColor = SystemColors.Desktop;
            checkBox_Pass.Location = new Point(792, 490);
            checkBox_Pass.Name = "checkBox_Pass";
            checkBox_Pass.Size = new Size(18, 17);
            checkBox_Pass.TabIndex = 13;
            checkBox_Pass.UseVisualStyleBackColor = false;
            checkBox_Pass.CheckedChanged += checkBox_Pass_CheckedChanged;
            // 
            // FormSignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1302, 792);
            Controls.Add(checkBox_Pass);
            Controls.Add(label1);
            Controls.Add(button_Login);
            Controls.Add(button_SignUp);
            Controls.Add(textBox_Email);
            Controls.Add(textBox_Name);
            Controls.Add(textBox_Password);
            Controls.Add(textBox_ConfirmPassword);
            Controls.Add(label_TieuDe2);
            Name = "FormSignUp";
            Text = "SignUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_TieuDe2;
        private TextBox textBox_ConfirmPassword;
        private TextBox textBox_Password;
        private TextBox textBox_Name;
        private TextBox textBox_Email;
        private Button button_SignUp;
        private Button button_Login;
        private Label label1;
        private CheckBox checkBox_Pass;
    }
}