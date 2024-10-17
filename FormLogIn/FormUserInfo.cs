using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogIn
{

    public partial class FormUserInfo : Form
    {
        private int _userId;
        string connectionString = @"Data Source=HACKER_LORD;Initial Catalog=LTHT_USER;Integrated Security=True";
        public FormUserInfo(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadUserInfo();
        }
        private void LoadUserInfo()
        {
            string queryUserName = "SELECT UserName, Email FROM USERS WHERE UserId = @userid";
            // LinQ 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(queryUserName, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", _userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox_Username.Text = reader["UserName"].ToString();
                                textBox_Email.Text = reader["Email"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception " + ex.Message);
                }
            }
        }
        private void textBox_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
