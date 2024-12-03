using System.Text;
using System.Net.Sockets;
using Client;

namespace FormLogIn
{
    public partial class FormLogin : Form
    {
        string ConnectString = @"Data Source=localhost;Initial Catalog=Bai_tap_ly_thuyet_3;Integrated Security=True";
        static TcpClient? client;
        static NetworkStream? stream;
        public FormLogin()
        {
            InitializeComponent();
        }
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
                BookSearch bookSearch = new BookSearch(response);
                bookSearch.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(response);
            }
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            string username = textBox_TenDangNhap.Text;
            string password = textBox_MatKhau.Text;
            string request = $"LOGIN;{username};{password}";
            SendAndReceive(request);
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
        private void btnForgetPass_Click(object sender, EventArgs e)
        {
            FormForgetPassword formForgetPassword = new FormForgetPassword();
            formForgetPassword.ShowDialog();
        }
    }
}