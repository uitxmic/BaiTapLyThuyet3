using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FormSever : Form
    {
        string ConnectString = @"Data Source=localhost;Initial Catalog=Bai_tap_ly_thuyet_3;Integrated Security=True";
        public FormSever()
        {
            InitializeComponent();
        }

        private void Show_Database()
        {
            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * from USERS", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = false;
            }
        }



        private void Show_database_Click(object sender, EventArgs e)
        {
            Show_Database();
        }

        private void Delete_row_Click(object sender, EventArgs e)
        {
            if  (MessageBox.Show("Are you sure to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    DataGridViewRow selectedrow = dataGridView1.Rows[rowIndex];
                    int userId = Convert.ToInt32(selectedrow.Cells[0].Value);

                    using (SqlConnection conn = new SqlConnection(ConnectString))
                    {
                        conn.Open();
                        using (SqlCommand cmm = new SqlCommand("DELETE FROM USERS WHERE UserId=@Userid", conn))
                        {
                            cmm.Parameters.AddWithValue("@UserId", userId);
                            cmm.ExecuteNonQuery();
                        }
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        MessageBox.Show("Successfully deleted.");
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
