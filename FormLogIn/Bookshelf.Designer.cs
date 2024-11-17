namespace Client
{
    partial class Bookshelf
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
            listBS = new ListView();
            Id = new ColumnHeader();
            Title = new ColumnHeader();
            VolCnt = new ColumnHeader();
            btnList = new Button();
            btnDel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // listBS
            // 
            listBS.Columns.AddRange(new ColumnHeader[] { Id, Title, VolCnt });
            listBS.GridLines = true;
            listBS.Location = new Point(12, 47);
            listBS.Name = "listBS";
            listBS.Size = new Size(776, 391);
            listBS.TabIndex = 0;
            listBS.UseCompatibleStateImageBehavior = false;
            listBS.View = View.Details;
            listBS.SelectedIndexChanged += listBS_SelectedIndexChanged;
            listBS.Click += listBS_Click;
            // 
            // Id
            // 
            Id.Text = "ID";
            // 
            // Title
            // 
            Title.Text = "Title";
            Title.Width = 200;
            // 
            // VolCnt
            // 
            VolCnt.Text = "Volume Count";
            VolCnt.TextAlign = HorizontalAlignment.Center;
            VolCnt.Width = 150;
            // 
            // btnList
            // 
            btnList.Location = new Point(10, 12);
            btnList.Name = "btnList";
            btnList.Size = new Size(168, 29);
            btnList.TabIndex = 1;
            btnList.Text = "List all bookshelves";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(184, 12);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(168, 29);
            btnDel.TabIndex = 2;
            btnDel.Text = "Select Bookshelf";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 16);
            label1.Name = "label1";
            label1.Size = new Size(368, 20);
            label1.TabIndex = 3;
            label1.Text = "Please click on an ID to view the bookshelf's volume(s)";
            label1.Click += label1_Click;
            // 
            // Bookshelf
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnDel);
            Controls.Add(btnList);
            Controls.Add(listBS);
            Name = "Bookshelf";
            Text = "Bookshelf";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listBS;
        private Button btnList;
        private ColumnHeader Id;
        private ColumnHeader Title;
        private ColumnHeader VolCnt;
        private Button btnDel;
        private Label label1;
    }
}