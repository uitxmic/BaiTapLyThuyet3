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

namespace FormLogIn
{
    public partial class FormSignUp : Form
    {
        string connectionString = @"Data Source=DESKTOP-R273SF4;Initial Catalog=LTHT_USER;Integrated Security=True";
        string query = "INSERT INTO USERS (UserName, PassWord, Email) VALUES (@UserName, @PassWord, @Email)";
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataTable dt;
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

        private void label_TieuDe_Click(object sender, EventArgs e)
        {

        }

        private void label_TieuDe2_Click(object sender, EventArgs e)
        {

        }

        private void label_Name_Click(object sender, EventArgs e)
        {

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

        private void label_Password_Click(object sender, EventArgs e)
        {

        }

        private void label_ConfirmPassword_Click(object sender, EventArgs e)
        {

        }

        private void label_Email_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Email_TextChanged(object sender, EventArgs e)
        {

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

        private void button_SignUp_Click(object sender, EventArgs e)
        {
            if (!IsValid(textBox_Email.Text))
            {
                MessageBox.Show("Your email is invalid");
            }
            string hashedPassWord = ComputeSha256Hash(textBox_Password.Text);
            string ComparePass = ComputeSha256Hash(textBox_ConfirmPassword.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (string.IsNullOrWhiteSpace(textBox_Name.Text) ||
               string.IsNullOrWhiteSpace(textBox_Password.Text) ||
               string.IsNullOrWhiteSpace(textBox_Email.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin!");
                }

                if (!ComparePass.Equals(hashedPassWord))
                {
                    textBox_Password.Clear();
                    textBox_ConfirmPassword.Clear();
                    throw new Exception("Your Password is not match!");
                }
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("UserName", textBox_Name.Text.Trim());
                        cmd.Parameters.AddWithValue("PassWord", hashedPassWord);
                        cmd.Parameters.AddWithValue("Email", textBox_Email.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Insert Sucessful");
                            textBox_Email.Clear();
                            textBox_Password.Clear();
                            textBox_Name.Clear();
                            textBox_ConfirmPassword.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Insert not sucessful");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Vui lòng nhập đủ các ô!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error {ex.Message}");
                }
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("UserName", textBox_Name.Text.Trim());
                        cmd.Parameters.AddWithValue("PassWord", hashedPassWord);
                        cmd.Parameters.AddWithValue("Email", textBox_Email.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sign up sucessfully");
                            textBox_Email.Clear();
                            textBox_Password.Clear();
                            textBox_Name.Clear();
                            textBox_ConfirmPassword.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Error Occur. Try Again");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Vui lòng nhập đủ các ô!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error {ex.Message}");
                }
            }
        }

        private void label_NotiFalsePass_Click(object sender, EventArgs e)
        {

        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }
    }
}
