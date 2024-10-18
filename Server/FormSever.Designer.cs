namespace Server
{
    partial class FormSever
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
            this.Show_database = new System.Windows.Forms.Button();
            this.Delete_row = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Show_database
            // 
            this.Show_database.Location = new System.Drawing.Point(62, 120);
            this.Show_database.Name = "Show_database";
            this.Show_database.Size = new System.Drawing.Size(112, 43);
            this.Show_database.TabIndex = 1;
            this.Show_database.Text = "Show database";
            this.Show_database.UseVisualStyleBackColor = true;
            this.Show_database.Click += new System.EventHandler(this.Show_database_Click);
            // 
            // Delete_row
            // 
            this.Delete_row.Location = new System.Drawing.Point(62, 221);
            this.Delete_row.Name = "Delete_row";
            this.Delete_row.Size = new System.Drawing.Size(112, 43);
            this.Delete_row.TabIndex = 2;
            this.Delete_row.Text = "Delete row";
            this.Delete_row.UseVisualStyleBackColor = true;
            this.Delete_row.Click += new System.EventHandler(this.Delete_row_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Location = new System.Drawing.Point(273, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(865, 305);
            this.dataGridView1.TabIndex = 3;
            // 
            // FormSever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 421);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Delete_row);
            this.Controls.Add(this.Show_database);
            this.Name = "FormSever";
            this.Text = "FormSever";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Show_database;
        private System.Windows.Forms.Button Delete_row;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}