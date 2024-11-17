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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // rtbDetails
            // 
            rtbDetails.Location = new Point(12, 215);
            rtbDetails.Name = "rtbDetails";
            rtbDetails.ReadOnly = true;
            rtbDetails.Size = new Size(458, 326);
            rtbDetails.TabIndex = 0;
            rtbDetails.Text = "";
            // 
            // btnAddToShelf
            // 
            btnAddToShelf.Location = new Point(12, 130);
            btnAddToShelf.Name = "btnAddToShelf";
            btnAddToShelf.Size = new Size(174, 30);
            btnAddToShelf.TabIndex = 1;
            btnAddToShelf.Text = "Add to shelf";
            btnAddToShelf.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFromShelf
            // 
            btnRemoveFromShelf.Location = new Point(192, 130);
            btnRemoveFromShelf.Name = "btnRemoveFromShelf";
            btnRemoveFromShelf.Size = new Size(144, 30);
            btnRemoveFromShelf.TabIndex = 2;
            btnRemoveFromShelf.Text = "Remove from shelf";
            btnRemoveFromShelf.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 166);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(324, 30);
            progressBar1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(76, 51);
            label1.Name = "label1";
            label1.Size = new Size(183, 38);
            label1.TabIndex = 4;
            label1.Text = "Book Details";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(342, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 184);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // BookInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 553);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(btnRemoveFromShelf);
            Controls.Add(btnAddToShelf);
            Controls.Add(rtbDetails);
            Name = "BookInfo";
            Text = "BookInfo";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbDetails;
        private Button btnAddToShelf;
        private Button btnRemoveFromShelf;
        private ProgressBar progressBar1;
        private Label label1;
        private PictureBox pictureBox1;
    }
}