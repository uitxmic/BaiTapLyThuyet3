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
    public partial class FormForgetPassword : Form
    {
        public FormForgetPassword()
        {
            InitializeComponent();
        }

        private async void btnRequestPass_Click(object sender, EventArgs e)
        {
            string serverIP = "127.0.0.1"; // Địa chỉ IP của server
            int port = 5555; // Port của server
            string email = txtEmail.Text; // Email cần kiểm tra

            try
            {
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(serverIP, port);

                    using (NetworkStream stream = client.GetStream())
                    {
                        // Tạo yêu cầu kiểm tra email và đặt lại mật khẩu
                        string request = "RESETPASSWORD;" + email;
                        byte[] requestBytes = Encoding.Unicode.GetBytes(request);

                        // Gửi yêu cầu tới server
                        await stream.WriteAsync(requestBytes, 0, requestBytes.Length);

                        // Đọc phản hồi từ server
                        byte[] buffer = new byte[4096];
                        int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
                        string response = Encoding.Unicode.GetString(buffer, 0, byteCount);

                        // Hiển thị phản hồi từ server
                        MessageBox.Show("Server response: " + response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
