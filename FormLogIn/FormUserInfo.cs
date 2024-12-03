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
using Client;
using Newtonsoft.Json;

namespace FormLogIn
{
    public partial class FormUserInfo : Form
    {
        private string Response;
        public FormUserInfo(string response)
        {
            InitializeComponent();
            Response = response;
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

        private void btnList_Click(object sender, EventArgs e)
        {
            Client.Bookshelf ins = new Client.Bookshelf();
            ins.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(textBox_Email.Text);
            changePassword.ShowDialog();
        }

        private void btnSignout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void btnBacktoBookSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookSearch bookSearch = new BookSearch(Response);
            bookSearch.ShowDialog();
        }
    }
}

