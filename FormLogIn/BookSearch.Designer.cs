namespace Client
{
    partial class BookSearch
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
            dgvBooks = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnCreateShelf = new Button();
            txtShelfTitle = new TextBox();
            txtShelfDescription = new TextBox();
            progressBar1 = new ProgressBar();
            lvShelf = new ListView();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(22, 29);
            label1.Name = "label1";
            label1.Size = new Size(190, 32);
            label1.TabIndex = 0;
            label1.Text = "Google Book";
            // 
            // dgvBooks
            // 
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(231, 90);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.Size = new Size(739, 351);
            dgvBooks.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 10.2F);
            txtSearch.Location = new Point(231, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search for books";
            txtSearch.Size = new Size(739, 27);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft Sans Serif", 10.2F);
            btnSearch.Location = new Point(231, 45);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(214, 39);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnCreateShelf
            // 
            btnCreateShelf.Font = new Font("Microsoft Sans Serif", 10.2F);
            btnCreateShelf.Location = new Point(12, 85);
            btnCreateShelf.Name = "btnCreateShelf";
            btnCreateShelf.Size = new Size(200, 34);
            btnCreateShelf.TabIndex = 4;
            btnCreateShelf.Text = "Create new shelf";
            btnCreateShelf.UseVisualStyleBackColor = true;
            // 
            // txtShelfTitle
            // 
            txtShelfTitle.Font = new Font("Microsoft Sans Serif", 10.2F);
            txtShelfTitle.Location = new Point(12, 125);
            txtShelfTitle.Name = "txtShelfTitle";
            txtShelfTitle.PlaceholderText = "Shelf's name";
            txtShelfTitle.Size = new Size(200, 27);
            txtShelfTitle.TabIndex = 5;
            // 
            // txtShelfDescription
            // 
            txtShelfDescription.Font = new Font("Microsoft Sans Serif", 10.2F);
            txtShelfDescription.Location = new Point(12, 158);
            txtShelfDescription.Name = "txtShelfDescription";
            txtShelfDescription.PlaceholderText = "Shelf's description";
            txtShelfDescription.Size = new Size(200, 27);
            txtShelfDescription.TabIndex = 6;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(451, 45);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(519, 39);
            progressBar1.TabIndex = 7;
            // 
            // lvShelf
            // 
            lvShelf.Font = new Font("Microsoft Sans Serif", 10.2F);
            lvShelf.Location = new Point(12, 191);
            lvShelf.Name = "lvShelf";
            lvShelf.Size = new Size(200, 250);
            lvShelf.TabIndex = 8;
            lvShelf.UseCompatibleStateImageBehavior = false;
            // 
            // BookSearch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 453);
            Controls.Add(lvShelf);
            Controls.Add(progressBar1);
            Controls.Add(txtShelfDescription);
            Controls.Add(txtShelfTitle);
            Controls.Add(btnCreateShelf);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvBooks);
            Controls.Add(label1);
            Name = "BookSearch";
            Text = "BookSearch";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvBooks;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnCreateShelf;
        private TextBox txtShelfTitle;
        private TextBox txtShelfDescription;
        private ProgressBar progressBar1;
        private ListView lvShelf;
    }
}