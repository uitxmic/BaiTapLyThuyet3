namespace Client
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
            textBox_Fullname = new TextBox();
            textBox_DateofBirth = new TextBox();
            textBox_Email = new TextBox();
            SuspendLayout();
            // 
            // textBox_Username
            // 
            textBox_Username.BackColor = SystemColors.InfoText;
            textBox_Username.BorderStyle = BorderStyle.None;
            textBox_Username.ForeColor = SystemColors.Window;
            textBox_Username.Location = new Point(519, 266);
            textBox_Username.Name = "textBox_Username";
            textBox_Username.Size = new Size(239, 20);
            textBox_Username.TabIndex = 0;
            // 
            // textBox_Fullname
            // 
            textBox_Fullname.BackColor = SystemColors.InfoText;
            textBox_Fullname.BorderStyle = BorderStyle.None;
            textBox_Fullname.ForeColor = SystemColors.Window;
            textBox_Fullname.Location = new Point(519, 358);
            textBox_Fullname.Name = "textBox_Fullname";
            textBox_Fullname.Size = new Size(239, 20);
            textBox_Fullname.TabIndex = 1;
            // 
            // textBox_DateofBirth
            // 
            textBox_DateofBirth.BackColor = SystemColors.InfoText;
            textBox_DateofBirth.BorderStyle = BorderStyle.None;
            textBox_DateofBirth.ForeColor = SystemColors.Window;
            textBox_DateofBirth.Location = new Point(519, 436);
            textBox_DateofBirth.Name = "textBox_DateofBirth";
            textBox_DateofBirth.Size = new Size(239, 20);
            textBox_DateofBirth.TabIndex = 2;
            // 
            // textBox_Email
            // 
            textBox_Email.BackColor = SystemColors.InfoText;
            textBox_Email.BorderStyle = BorderStyle.None;
            textBox_Email.ForeColor = SystemColors.Window;
            textBox_Email.Location = new Point(519, 523);
            textBox_Email.Name = "textBox_Email";
            textBox_Email.Size = new Size(239, 20);
            textBox_Email.TabIndex = 3;
            // 
            // FormUserInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1228, 629);
            Controls.Add(textBox_Email);
            Controls.Add(textBox_DateofBirth);
            Controls.Add(textBox_Fullname);
            Controls.Add(textBox_Username);
            ForeColor = SystemColors.Control;
            Name = "FormUserInfo";
            Text = "FormUserInfo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_Username;
        private TextBox textBox_Fullname;
        private TextBox textBox_DateofBirth;
        private TextBox textBox_Email;
    }
}