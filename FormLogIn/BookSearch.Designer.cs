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
            btnShowShelf = new Button();
            progressBar1 = new ProgressBar();
            Name = new DataGridViewTextBoxColumn();
            Author = new DataGridViewTextBoxColumn();
            clTitle = new DataGridViewTextBoxColumn();
            clAuthor = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(21, 28);
            label1.Name = "label1";
            label1.Size = new Size(190, 32);
            label1.TabIndex = 0;
            label1.Text = "Google Book";
            // 
            // dgvBooks
            // 
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(12, 90);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.Size = new Size(958, 351);
            dgvBooks.TabIndex = 1;
            dgvBooks.CellContentClick += dgvBooks_CellContentClick;
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
            // btnShowShelf
            // 
            btnShowShelf.Font = new Font("Microsoft Sans Serif", 10.2F);
            btnShowShelf.Location = new Point(451, 45);
            btnShowShelf.Name = "btnShowShelf";
            btnShowShelf.Size = new Size(200, 39);
            btnShowShelf.TabIndex = 4;
            btnShowShelf.Text = "Bookshelf List";
            btnShowShelf.UseVisualStyleBackColor = true;
            btnShowShelf.Click += btnCreateShelf_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(657, 45);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(313, 39);
            progressBar1.TabIndex = 7;
            // 
            // Name
            // 
            Name.HeaderText = "Name";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.ReadOnly = true;
            Name.Resizable = DataGridViewTriState.False;
            Name.Width = 350;
            // 
            // Author
            // 
            Author.HeaderText = "Author";
            Author.MinimumWidth = 6;
            Author.Name = "Author";
            Author.ReadOnly = true;
            Author.Resizable = DataGridViewTriState.False;
            Author.Width = 349;
            // 
            // clTitle
            // 
            clTitle.HeaderText = "Tile";
            clTitle.MinimumWidth = 6;
            clTitle.Name = "clTitle";
            clTitle.Width = 349;
            // 
            // clAuthor
            // 
            clAuthor.HeaderText = "Author";
            clAuthor.MinimumWidth = 6;
            clAuthor.Name = "clAuthor";
            clAuthor.Width = 349;
            // 
            // BookSearch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 453);
            Controls.Add(progressBar1);
            Controls.Add(btnShowShelf);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvBooks);
            Controls.Add(label1);
            //Name = "BookSearch";
            Text = "Book Search";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvBooks;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnShowShelf;
        private ProgressBar progressBar1;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn clTitle;
        private DataGridViewTextBoxColumn clAuthor;
    }
}