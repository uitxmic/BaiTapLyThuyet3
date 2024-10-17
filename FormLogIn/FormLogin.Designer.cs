namespace FormLogIn
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            textBox_TenDangNhap = new TextBox();
            button_Login = new Button();
            textBox_MatKhau = new TextBox();
            button_Close = new Button();
            checkBox_RevealPass = new CheckBox();
            button_SignUp = new Button();
            label_TieuDe2 = new Label();
            label_TieuDe = new Label();
            SuspendLayout();
            // 
            // textBox_TenDangNhap
            // 
            textBox_TenDangNhap.BackColor = SystemColors.WindowText;
            textBox_TenDangNhap.BorderStyle = BorderStyle.None;
            textBox_TenDangNhap.ForeColor = SystemColors.Window;
            textBox_TenDangNhap.Location = new Point(516, 266);
            textBox_TenDangNhap.Multiline = true;
            textBox_TenDangNhap.Name = "textBox_TenDangNhap";
            textBox_TenDangNhap.PlaceholderText = "Email or Username";
            textBox_TenDangNhap.Size = new Size(250, 27);
            textBox_TenDangNhap.TabIndex = 2;
            textBox_TenDangNhap.TextChanged += textBox_TenDangNhap_TextChanged;
            // 
            // button_Login
            // 
            button_Login.Location = new Point(554, 411);
            button_Login.Name = "button_Login";
            button_Login.Size = new Size(171, 43);
            button_Login.TabIndex = 3;
            button_Login.Text = "Login";
            button_Login.UseVisualStyleBackColor = true;
            button_Login.Click += button_Login_Click;
            // 
            // textBox_MatKhau
            // 
            textBox_MatKhau.BackColor = SystemColors.WindowText;
            textBox_MatKhau.BorderStyle = BorderStyle.None;
            textBox_MatKhau.ForeColor = SystemColors.Window;
            textBox_MatKhau.Location = new Point(516, 356);
            textBox_MatKhau.Multiline = true;
            textBox_MatKhau.Name = "textBox_MatKhau";
            textBox_MatKhau.PasswordChar = '*';
            textBox_MatKhau.PlaceholderText = "Password";
            textBox_MatKhau.Size = new Size(250, 33);
            textBox_MatKhau.TabIndex = 4;
            textBox_MatKhau.TextChanged += textBox_MatKhau_TextChanged;
            // 
            // button_Close
            // 
            button_Close.Location = new Point(554, 564);
            button_Close.Name = "button_Close";
            button_Close.Size = new Size(171, 52);
            button_Close.TabIndex = 5;
            button_Close.Text = "Close";
            button_Close.UseVisualStyleBackColor = true;
            button_Close.Click += button_Close_Click;
            // 
            // checkBox_RevealPass
            // 
            checkBox_RevealPass.AutoSize = true;
            checkBox_RevealPass.BackColor = SystemColors.ControlText;
            checkBox_RevealPass.Location = new Point(801, 352);
            checkBox_RevealPass.Name = "checkBox_RevealPass";
            checkBox_RevealPass.Size = new Size(18, 17);
            checkBox_RevealPass.TabIndex = 6;
            checkBox_RevealPass.UseVisualStyleBackColor = false;
            checkBox_RevealPass.CheckedChanged += checkBox_RevealPass_CheckedChanged;
            // 
            // button_SignUp
            // 
            button_SignUp.Location = new Point(706, 486);
            button_SignUp.Name = "button_SignUp";
            button_SignUp.Size = new Size(171, 46);
            button_SignUp.TabIndex = 7;
            button_SignUp.Text = "Sign Up";
            button_SignUp.UseVisualStyleBackColor = true;
            button_SignUp.Click += button_SignUp_Click;
            // 
            // label_TieuDe2
            // 
            label_TieuDe2.AutoSize = true;
            label_TieuDe2.Location = new Point(120, 129);
            label_TieuDe2.Name = "label_TieuDe2";
            label_TieuDe2.Size = new Size(0, 20);
            label_TieuDe2.TabIndex = 1;
            label_TieuDe2.Click += label_TieuDe2_Click;
            // 
            // label_TieuDe
            // 
            label_TieuDe.AutoSize = true;
            label_TieuDe.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label_TieuDe.Location = new Point(116, 72);
            label_TieuDe.Name = "label_TieuDe";
            label_TieuDe.Size = new Size(0, 57);
            label_TieuDe.TabIndex = 0;
            label_TieuDe.Click += label_TieuDe_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1312, 685);
            Controls.Add(button_SignUp);
            Controls.Add(checkBox_RevealPass);
            Controls.Add(button_Close);
            Controls.Add(textBox_MatKhau);
            Controls.Add(button_Login);
            Controls.Add(textBox_TenDangNhap);
            Controls.Add(label_TieuDe2);
            Controls.Add(label_TieuDe);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "FormLogin";
            Text = "Form1";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox_TenDangNhap;
        private Button button_Login;
        private TextBox textBox_MatKhau;
        private Button button_Close;
        private CheckBox checkBox_RevealPass;
        private Button button_SignUp;
        private Label label_TieuDe2;
        private Label label_TieuDe;
    }
}
