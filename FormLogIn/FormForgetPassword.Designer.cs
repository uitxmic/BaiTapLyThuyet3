namespace Client
{
    partial class FormForgetPassword
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
            label1 = new Label();
            txtEmail = new TextBox();
            btnRequestPass = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhập vào Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(135, 14);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(269, 27);
            txtEmail.TabIndex = 1;
            // 
            // btnRequestPass
            // 
            btnRequestPass.Location = new Point(12, 57);
            btnRequestPass.Name = "btnRequestPass";
            btnRequestPass.Size = new Size(182, 29);
            btnRequestPass.TabIndex = 2;
            btnRequestPass.Text = "Yêu cầu lại mật khẩu";
            btnRequestPass.UseVisualStyleBackColor = true;
            btnRequestPass.Click += btnRequestPass_Click;
            // 
            // FormForgetPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 107);
            Controls.Add(btnRequestPass);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Name = "FormForgetPassword";
            Text = "FormForgetPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtEmail;
        private Button btnRequestPass;
    }
}