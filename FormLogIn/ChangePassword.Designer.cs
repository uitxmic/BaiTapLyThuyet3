namespace Client
{
    partial class ChangePassword
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
            txtCurrentPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtNewPassword = new TextBox();
            label3 = new Label();
            txtConfirmNewPassword = new TextBox();
            label4 = new Label();
            btnChangePassword = new Button();
            checkBox_RevealPassword = new CheckBox();
            SuspendLayout();
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(371, 113);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '*';
            txtCurrentPassword.Size = new Size(275, 27);
            txtCurrentPassword.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(198, 116);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 1;
            label1.Text = "Current password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(198, 167);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 3;
            label2.Text = "New password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(371, 164);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(275, 27);
            txtNewPassword.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(198, 220);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(163, 20);
            label3.TabIndex = 5;
            label3.Text = "Confirm new password:";
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.Location = new Point(371, 217);
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.PasswordChar = '*';
            txtConfirmNewPassword.Size = new Size(275, 27);
            txtConfirmNewPassword.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(332, 31);
            label4.Name = "label4";
            label4.Size = new Size(228, 31);
            label4.TabIndex = 6;
            label4.Text = "CHANGE PASWORD";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(422, 289);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(94, 29);
            btnChangePassword.TabIndex = 7;
            btnChangePassword.Text = "Thay đổi";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // checkBox_RevealPassword
            // 
            checkBox_RevealPassword.AutoSize = true;
            checkBox_RevealPassword.Location = new Point(697, 220);
            checkBox_RevealPassword.Name = "checkBox_RevealPassword";
            checkBox_RevealPassword.Size = new Size(140, 24);
            checkBox_RevealPassword.TabIndex = 8;
            checkBox_RevealPassword.Text = "Reveal Password";
            checkBox_RevealPassword.UseVisualStyleBackColor = true;
            checkBox_RevealPassword.CheckedChanged += checkBox_RevealPassword_CheckedChanged;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 450);
            Controls.Add(checkBox_RevealPassword);
            Controls.Add(btnChangePassword);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtConfirmNewPassword);
            Controls.Add(label2);
            Controls.Add(txtNewPassword);
            Controls.Add(label1);
            Controls.Add(txtCurrentPassword);
            Name = "ChangePassword";
            Text = "ChangePassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCurrentPassword;
        private Label label1;
        private Label label2;
        private TextBox txtNewPassword;
        private Label label3;
        private TextBox txtConfirmNewPassword;
        private Label label4;
        private Button btnChangePassword;
        private CheckBox checkBox_RevealPassword;
    }
}