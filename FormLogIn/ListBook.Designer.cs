namespace Client
{
    partial class ListBook
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
            list_book = new ListView();
            id = new ColumnHeader();
            title = new ColumnHeader();
            authors = new ColumnHeader();
            desc = new ColumnHeader();
            btnShow = new Button();
            btnInfo = new Button();
            SuspendLayout();
            // 
            // list_book
            // 
            list_book.Columns.AddRange(new ColumnHeader[] { id, title, authors, desc });
            list_book.GridLines = true;
            list_book.Location = new Point(12, 44);
            list_book.Name = "list_book";
            list_book.Size = new Size(776, 394);
            list_book.TabIndex = 0;
            list_book.UseCompatibleStateImageBehavior = false;
            list_book.View = View.Details;
            // 
            // id
            // 
            id.Text = "Id";
            id.Width = 100;
            // 
            // title
            // 
            title.Text = "title";
            title.Width = 200;
            // 
            // authors
            // 
            authors.Text = "Authors";
            authors.Width = 150;
            // 
            // desc
            // 
            desc.Text = "Description";
            desc.Width = 300;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(12, 9);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(171, 29);
            btnShow.TabIndex = 1;
            btnShow.Text = "Show Volumes";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // btnInfo
            // 
            btnInfo.Location = new Point(189, 9);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(179, 29);
            btnInfo.TabIndex = 2;
            btnInfo.Text = "View Book Info";
            btnInfo.UseVisualStyleBackColor = true;
            btnInfo.Click += btnInfo_Click;
            // 
            // ListBook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnInfo);
            Controls.Add(btnShow);
            Controls.Add(list_book);
            Name = "ListBook";
            Text = "ListBook";
            ResumeLayout(false);
        }

        #endregion

        private ListView list_book;
        private ColumnHeader id;
        private ColumnHeader title;
        private ColumnHeader authors;
        private ColumnHeader desc;
        private Button btnShow;
        private Button btnInfo;
    }
}