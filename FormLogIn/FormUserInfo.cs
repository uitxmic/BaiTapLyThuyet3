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
using Newtonsoft.Json;

namespace FormLogIn
{
    public partial class FormUserInfo : Form
    {
        public FormUserInfo(string response)
        {
            InitializeComponent();
            string[] parts = response.Split(';');
            if (parts[0] == "200")
            {
                textBox_Username.Text = parts[1];
                textBox_Fullname.Text = parts[2];
                textBox_Birthday.Text = parts[3];
                textBox_Email.Text = parts[4];
            }
            else
            {
                MessageBox.Show("An error has occurred. Please contact system administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Client.Bookshelf ins = new Client.Bookshelf();
            ins.Show();
        }
    }
}

