using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChangePassword : Form
    {
        string Usermail;
        public ChangePassword(string usermail)
        {
            InitializeComponent();
            Usermail = usermail;
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmNewPassword.Text;

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5555))
                {
                    NetworkStream stream = client.GetStream();
                    string request = $"CHANGEPASSWORD;{Usermail};{oldPassword};{newPassword}";
                    byte[] buffer = Encoding.Unicode.GetBytes(request);

                    await stream.WriteAsync(buffer, 0, buffer.Length);

                    byte[] responseBuffer = new byte[4096];
                    int byteCount = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                    string response = Encoding.Unicode.GetString(responseBuffer, 0, byteCount);

                    MessageBox.Show(response, "Server Response", MessageBoxButtons.OK, response.StartsWith("Success") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_RevealPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_RevealPassword.CheckState == CheckState.Checked)
            {
                txtConfirmNewPassword.UseSystemPasswordChar = true;
                txtCurrentPassword.UseSystemPasswordChar = true;
                txtNewPassword.UseSystemPasswordChar = true;
            }
            else                
            { 
                txtNewPassword.UseSystemPasswordChar = false;
                txtCurrentPassword.UseSystemPasswordChar= false;
                txtConfirmNewPassword.UseSystemPasswordChar = false;
            }          
        }
    }
}

