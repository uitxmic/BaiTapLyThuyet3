using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace FormLogIn
{
    public partial class FormLogin : Form
    {
        string ConnectString = @"Data Source=localhost;Initial Catalog=Bai_tap_ly_thuyet_3;Integrated Security=True";
        string query = "SELECT PassWord FROM USERS WHERE UserName = @username";
        public FormLogin()
        {
            InitializeComponent();
        }
        private void checkBox_RevealPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_RevealPass.CheckState == CheckState.Checked)
            {
                textBox_MatKhau.UseSystemPasswordChar = true;
            }
            else
                textBox_MatKhau.UseSystemPasswordChar = false;
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
        private void button_Login_Click(object sender, EventArgs e)
        {
            string username = textBox_TenDangNhap.Text;
            string enteredPassword = ComputeSha256Hash(textBox_MatKhau.Text);

            string query = "SELECT UserId FROM USERS WHERE UserName = @username AND PassWord = @password";

            int userId;

            using (SqlConnection connection = new SqlConnection(ConnectString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", enteredPassword); 

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            userId = Convert.ToInt32(result);
                            MessageBox.Show("Login Successful!");

                            FormUserInfo userInfo = new FormUserInfo(userId);
                            userInfo.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message);
                }
            }
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_SignUp_Click(object sender, EventArgs e)
        {
            FormSignUp formSignUp = new FormSignUp();
            formSignUp.ShowDialog();
        }
        private void label_TieuDe_Click(object sender, EventArgs e)
        {

        }
        private void label_TieuDe2_Click(object sender, EventArgs e)
        {

        }

    }
}