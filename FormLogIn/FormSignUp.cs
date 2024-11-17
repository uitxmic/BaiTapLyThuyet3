using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace FormLogIn
{
    public partial class FormSignUp : Form
    {
        
        static TcpClient? client;
        static NetworkStream? stream;
        void SendAndReceive(string request)
        {
            client = new TcpClient("127.0.0.1", 5555);
            stream = client.GetStream();
            byte[] requestData = Encoding.Unicode.GetBytes(request);
            stream.Write(requestData, 0, requestData.Length);
            byte[] buffer = new byte[4096];
            int byteCount = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.Unicode.GetString(buffer, 0, byteCount);
            HandleServerResponse(response);
            client.Close();
        }

        void HandleServerResponse(string response)
        {
            if (response.StartsWith("200"))
            {
                this.Close();
                MessageBox.Show("Sign up successfully!");
                ClearTextBox();
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
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|edu\.[a-z]{2})$";
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
        
        
        private void button_SignUp_Click(object sender, EventArgs e)
        {
            string request = "REGISTER;";
            if (string.IsNullOrWhiteSpace(textBox_Name.Text) ||
                string.IsNullOrWhiteSpace(textBox_Password.Text) ||
                string.IsNullOrWhiteSpace(textBox_Email.Text) ||
                string.IsNullOrWhiteSpace(textBox_ConfirmPassword.Text) ||
                string.IsNullOrWhiteSpace(textBox_Birthday.Text) ||
                string.IsNullOrWhiteSpace(textBox_FullName.Text))
            {
                MessageBox.Show("Please fill out all the form.");
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

            if (textBox_Password.Text.Length < 8) 
            { 
                MessageBox.Show("Your password is too short, needs to be more than or equal 8 characters.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBox_Password.Text != textBox_ConfirmPassword.Text)
            {
                MessageBox.Show("Your password is not match!");
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
    }
}
