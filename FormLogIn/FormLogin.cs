using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.ComponentModel.DataAnnotations;

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
            Task.Run(() => InitializeSocket("Hello"));
        }
        private void InitializeSocket(string request)
        {
            client = new TcpClient("127.0.0.1", 5555);
            stream = client.GetStream();
            MessageBox.Show("Connected to server...");
            byte[] requestData = Encoding.ASCII.GetBytes(request);
            stream.Write(requestData, 0, requestData.Length);
            byte[] buffer = new byte[1024];
            int byteCount = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, byteCount);
            MessageBox.Show("Server response: " + response);
            client.Close();
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
        private void button_Login_Click(object sender, EventArgs e)
        {
            string username = textBox_TenDangNhap.Text;
            string password = textBox_MatKhau.Text;
            string request = $"LOGIN;{username};{password}";
            InitializeSocket(request);
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