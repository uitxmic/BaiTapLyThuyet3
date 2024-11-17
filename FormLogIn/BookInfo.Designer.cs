namespace Client
{
    partial class BookInfo
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
            rtbDetails = new RichTextBox();
            btnAddToShelf = new Button();
            btnRemoveFromShelf = new Button();
            progressBar1 = new ProgressBar();
            label1 = new Label();
            SuspendLayout();
            // 
            // rtbDetails
            // 
            rtbDetails.Location = new Point(12, 138);
            rtbDetails.Name = "rtbDetails";
            rtbDetails.ReadOnly = true;
            rtbDetails.Size = new Size(458, 353);
            rtbDetails.TabIndex = 0;
            rtbDetails.Text = "";
            // 
            // btnAddToShelf
            // 
            btnAddToShelf.Location = new Point(306, 12);
            btnAddToShelf.Name = "btnAddToShelf";
            btnAddToShelf.Size = new Size(164, 30);
            btnAddToShelf.TabIndex = 1;
            btnAddToShelf.Text = "Add to shelf";
            btnAddToShelf.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFromShelf
            // 
            btnRemoveFromShelf.Location = new Point(306, 57);
            btnRemoveFromShelf.Name = "btnRemoveFromShelf";
            btnRemoveFromShelf.Size = new Size(164, 30);
            btnRemoveFromShelf.TabIndex = 2;
            btnRemoveFromShelf.Text = "Remove from shelf";
            btnRemoveFromShelf.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 102);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(458, 30);
            progressBar1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(62, 28);
            label1.Name = "label1";
            label1.Size = new Size(183, 38);
            label1.TabIndex = 4;
            label1.Text = "Book Details";
            // 
            // BookInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 503);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(btnRemoveFromShelf);
            Controls.Add(btnAddToShelf);
            Controls.Add(rtbDetails);
            Name = "BookInfo";
            Text = "BookInfo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbDetails;
        private Button btnAddToShelf;
        private Button btnRemoveFromShelf;
        private ProgressBar progressBar1;
        private Label label1;
    }
}