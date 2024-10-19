using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogIn
{
    public partial class FormSignUp : Form
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=Bai_tap_ly_thuyet_3;Integrated Security=True";
        string query = "INSERT INTO USERS (UserName, PassWord, Email, BirthDay, FullName) VALUES (@UserName, @PassWord, @Email, @Birthday, @FullName)";
        static TcpClient client;
        static NetworkStream stream;
        void SendAndReceive(string request)
        {
            client = new TcpClient("127.0.0.1", 5555);
            stream = client.GetStream();
            byte[] requestData = Encoding.ASCII.GetBytes(request);
            stream.Write(requestData, 0, requestData.Length);
            byte[] buffer = new byte[4096];
            int byteCount = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, byteCount);
            HandleServerResponse(response);
            client.Close();
        }
        void HandleServerResponse(string response)
        {
            if (response.StartsWith("200"))
            {
                FormUserInfo fui = new FormUserInfo(response);
                fui.Show();
            }
            else MessageBox.Show(response);
        }
        public FormSignUp()
        {
            InitializeComponent();
            textBox_Name.Focus();
            textBox_Password.UseSystemPasswordChar = true;
            textBox_ConfirmPassword.UseSystemPasswordChar = true;
        }
        private static bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
        private void checkBox_Pass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Pass.CheckState == CheckState.Checked)
            {
                textBox_Password.UseSystemPasswordChar = false;
                textBox_ConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_Password.UseSystemPasswordChar = true;
                textBox_ConfirmPassword.UseSystemPasswordChar = true;
            }
        }
        private bool IsUserNameExists(string userName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string checkQuery = "SELECT COUNT(1) FROM USERS WHERE UserName = @UserName";
                    using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("UserName", userName);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] bytes = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        private void ClearTextBox()
        {
            textBox_Email.Clear();
            textBox_Password.Clear();
            textBox_Name.Clear();
            textBox_ConfirmPassword.Clear();
            textBox_FullName.Clear();
            textBox_Birthday.Clear();
        }
        string request = "REGISTER;";
        
        private void button_SignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Name.Text) ||
                string.IsNullOrWhiteSpace(textBox_Password.Text) ||
                string.IsNullOrWhiteSpace(textBox_Email.Text) ||
                string.IsNullOrWhiteSpace(textBox_ConfirmPassword.Text) ||
                string.IsNullOrWhiteSpace(textBox_Birthday.Text) ||
                string.IsNullOrWhiteSpace(textBox_FullName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!IsValid(textBox_Email.Text))
            {
                MessageBox.Show("Your email is invalid");
                return;
            }

            DateTime birthday;
            if (!DateTime.TryParse(textBox_Birthday.Text, out birthday))
            {
                MessageBox.Show("Invalid date format. Please enter a valid date.");
                return;
            }

            if (textBox_Password.Text != textBox_ConfirmPassword.Text)
            {
                MessageBox.Show("Your Password is not match!");
                return;
            }

            try
            {
                request += textBox_Name.Text.Trim() + ';' + textBox_Password.Text + ';' + textBox_Email.Text + ';' + birthday.Date + ';' + textBox_FullName.Text;
                SendAndReceive(request);
            }
            catch (Exception ex) { MessageBox.Show($"Input Error: {ex.Message}: {ex.TargetSite}"); }
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
