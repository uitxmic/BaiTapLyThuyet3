using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.ComponentModel.DataAnnotations;
using Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FormLogIn
{
    public partial class FormLogin : Form
    {
        string ConnectString = @"Data Source=localhost;Initial Catalog=Bai_tap_ly_thuyet_3;Integrated Security=True";
        static TcpClient client;
        static NetworkStream stream;
        public FormLogin()
        {
            InitializeComponent();
        }
        void SendToTCPServer(string request)
        {
            client = new TcpClient("127.0.0.1", 5555);
            stream = client.GetStream();

            byte[] requestData = Encoding.ASCII.GetBytes(request);
            stream.Write(requestData, 0, requestData.Length);

            byte[] buffer = new byte[4096];
            int byteCount = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, byteCount);

            // Log the raw response to debug
            Console.WriteLine("Raw response from server: " + response);

            HandleServerResponse(response);
            client.Close();
        }
        bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || // For object
                (strInput.StartsWith("[") && strInput.EndsWith("]")))   // For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        void HandleServerResponse(string response)
        {
            try
            {
                // Log the response string before deserialization
                MessageBox.Show("Server response to be parsed: " + response);

                // Check if the response is a valid JSON string
                if (IsValidJson(response))
                {
                    UserInfor userInfo = JsonConvert.DeserializeObject<UserInfor>(response);
                    if (userInfo != null)
                    {
                        // Pass the deserialized object to FormUserInfo for display
                        FormUserInfo formUserInfo = new FormUserInfo(userInfo);
                        formUserInfo.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve user information from the server.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing server response: {ex.Message}");
            }
        }
        private void button_Login_Click(object sender, EventArgs e)
        {
            string username = textBox_TenDangNhap.Text;
            string password = textBox_MatKhau.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty!");
                return;
            }

            string hashedPassword = ComputeSha256Hash(password);
            // Create a JSON object for the login request
            var loginRequest = new
            {
                action = "LOGIN",
                username = username,
                password = hashedPassword
            };

            // Serialize the object to JSON string
            string request = JsonConvert.SerializeObject(loginRequest);
            MessageBox.Show($"{ request}");
            SendToTCPServer(request);
        }

        // Hash function for password
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
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