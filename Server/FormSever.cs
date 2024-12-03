using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;

namespace Server
{
    public partial class FormSever : Form
    {
        static string ConnectString = @"Data Source=localhost;Initial Catalog=Bai_tap_ly_thuyet_3;Integrated Security=True";
        static TcpListener listener;
        static List<TcpClient> clients = new List<TcpClient>();
        public FormSever()
        {
            InitializeComponent();
            Task.Run(() => InitializeListener());
        }
        private void InitializeListener()
        {
            richTextBox1.Clear();
            listener = new TcpListener(IPAddress.Any, 5555);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                clients.Add(client);
                IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                string clientIP = clientEndPoint?.Address.ToString();
                richTextBox1.AppendText($"New connection from {clientIP}!\n");
                Task.Run(() => HandleClient(client));
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
        private async void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[4096];
            int byteCount;
            try
            {
                while ((byteCount = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string request = Encoding.Unicode.GetString(buffer, 0, byteCount);
                    string response = await HandleRequestAsync(request);
                    byte[] responseData = Encoding.Unicode.GetBytes(response);
                    await stream.WriteAsync(responseData, 0, responseData.Length);
                }
                clients.Remove(client);
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsUserNameExists(string userName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
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
        private async Task<string> HandleRequestAsync(string request)
        {
            if (request.StartsWith("LOGIN"))
            {
                string[] parts = request.Split(';');
                if (parts.Length < 3)
                {
                    return "Invalid login request";
                }
                string username = parts[1];
                string password = ComputeSha256Hash(parts[2]);
                return LoginQuery(username, password);
            }

            if (request.StartsWith("REGISTER"))
            {
                string[] parts = request.Split(';');
                if (parts.Length != 6) return "Invalid login request";
                string usr = parts[1];

                if (IsUserNameExists(usr)) return "Username already exists.";
                return SignupQuery(parts);
            }
            if (request.StartsWith("RESETPASSWORD"))
            {
                string email = request.Split(';')[1];
                if (IsEmailExists(email))
                {
                    string newPassword = GenerateRandomPassword();
                    if (UpdatePasswordInDatabaseByEmail(email, newPassword))
                    {
                        if (await SendEmailAsync(email, newPassword))
                        {
                            return "Password reset and email sent successfully.";
                        }
                        else
                        {
                            return "Failed to send email.";
                        }
                    }
                    else
                    {
                        return "Failed to update password in database.";
                    }
                }
                else
                {
                    return "Email does not exist in database.";
                }
            }
            if (request.StartsWith("CHANGEPASSWORD"))
            {
                string[] parts = request.Split(';');
                if (parts.Length != 4)
                {
                    return "Invalid change password request.";
                }

                string email = parts[1];
                string oldPasswordHash = ComputeSha256Hash(parts[2]);

                if (ValidateCurrentPassword(email, oldPasswordHash))
                {
                    if (UpdatePasswordInDatabaseByEmail(email, parts[3]))
                    {
                        return "Success: Password changed successfully.";
                    }
                    else
                    {
                        return "Failed: Could not update password in database.";
                    }
                }
                else
                {
                    return "Failed: Incorrect current password.";
                }
            }

            return "Unknown request";
        }

        private bool IsEmailExists(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    string checkQuery = "SELECT COUNT(1) FROM USERS WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("Email", email);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool ValidateCurrentPassword(string email, string passwordHash)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    string query = "SELECT COUNT(1) FROM USERS WHERE Email = @Email AND PassWord = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("Email", email);
                        cmd.Parameters.AddWithValue("Password", passwordHash);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private string GenerateRandomPassword(int length = 8)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                sb.Append(validChars[rnd.Next(validChars.Length)]);
            }
            return sb.ToString();
        }

        private bool UpdatePasswordInDatabaseByEmail(string email, string newPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    string updateQuery = "UPDATE USERS SET PassWord = @Password WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("Password", ComputeSha256Hash(newPassword));
                        cmd.Parameters.AddWithValue("Email", email);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private async Task<bool> SendEmailAsync(string email, string newPassword)
            {
                string senderEmail = "khoibaochien@gmail.com";
                string senderPassword = "krti dtle hdjb exew";
                string subject = "Reset Password";
                string body = $@"
                <!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Reset Password</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            margin: 0;
                            padding: 0;
                            background-color: #f4f4f4;
                        }}
                        .container {{
                            width: 100%;
                            max-width: 600px;
                            margin: 0 auto;
                            padding: 20px;
                            background-color: #ffffff;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                        }}
                        .header {{
                            text-align: center;
                            padding: 10px 0;
                            border-bottom: 1px solid #dddddd;
                        }}
                        .content {{
                            padding: 20px 0;
                        }}
                        .footer {{
                            text-align: center;
                            padding: 10px 0;
                            border-top: 1px solid #dddddd;
                            font-size: 12px;
                            color: #999999;
                        }}
                        .button {{
                            display: inline-block;
                            padding: 10px 20px;
                            margin-top: 20px;
                            background-color: #28a745;
                            color: #ffffff;
                            text-decoration: none;
                            border-radius: 5px;
                        }}
                    </style>
                </head>
                <body>
                    <div class=""container"">
                        <div class=""header"">
                            <h2>Password Reset</h2>
                        </div>
                        <div class=""content"">
                            <p>Dear User,</p>
                            <p>Your new password is:</p>
                            <p><strong>{newPassword}</strong></p>
                            <p>Please use this new password to log in with your username. We recommend changing your password once you have successfully logged in.</p>
                        </div>
                        <div class=""footer"">
                            <p>If you did not request this password reset, please contact our support team immediately.</p>
                            <p>Thank you,<br>Group 5</p>
                        </div>
                    </div>
                </body>
                </html>";

            var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Reset Password From Group 5", senderEmail));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    try
                    {
                        // Kết nối với máy chủ SMTP
                        await client.ConnectAsync("smtp.gmail.com", 465, true);

                        // Xác thực với máy chủ SMTP
                        await client.AuthenticateAsync(senderEmail, senderPassword);

                        // Gửi email
                        await client.SendAsync(message);

                        // Ngắt kết nối
                        await client.DisconnectAsync(true);

                        MessageBox.Show("Email sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

    string query = "INSERT INTO USERS (UserName, PassWord, Email, BirthDay, FullName) VALUES (@UserName, @PassWord, @Email, @Birthday, @FullName)";
        private string SignupQuery(string[] request)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("UserName", request[1].Trim());
                        cmd.Parameters.AddWithValue("PassWord", ComputeSha256Hash(request[2]));
                        cmd.Parameters.AddWithValue("Email", request[3]);
                        if (DateTime.TryParse(request[4], out DateTime dt))
                            cmd.Parameters.AddWithValue("Birthday", dt);
                        cmd.Parameters.AddWithValue("FullName", request[5].Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        string response = "200;";
                        response += request[1].Trim() + ';';
                        response += request[5].Trim() + ';';
                        response += dt.ToString("dd/MM/yyyy") + ";";
                        response += request[3] + ";";
                        if (rowsAffected > 0)
                        {
                            conn.Close();
                            return response;
                        }
                        else
                        {
                            conn.Close();
                            return "301;Error Occur.;[NULL];[NULL];[NULL]";
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return "Database Signup Error: " + ex.Message;
            }
        }
        private string LoginQuery(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UserName, FullName, BirthDay, Email FROM USERS WHERE UserName = @username AND PassWord = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userName = reader["UserName"].ToString();
                                string fullName = reader["FullName"].ToString();
                                DateTime birthDay = Convert.ToDateTime(reader["BirthDay"]);
                                string email = reader["Email"].ToString();
                                return $"200;{userName};{fullName};{birthDay.ToString("yyyy/MM/dd")};{email}";
                            }
                            else
                            {
                                return "Invalid username or password!";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "Database Error: " + ex.Message;
                }
            }
        }
        private void Show_Database()
        {
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * from USERS", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        private void Show_database_Click(object sender, EventArgs e)
        {
            Show_Database();
        }
        private void Delete_row_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    DataGridViewRow selectedrow = dataGridView1.Rows[rowIndex];
                    int userId = Convert.ToInt32(selectedrow.Cells[0].Value);

                    using (SqlConnection conn = new SqlConnection(ConnectString))
                    {
                        conn.Open();
                        using (SqlCommand cmm = new SqlCommand("DELETE FROM USERS WHERE UserId=@Userid", conn))
                        {
                            cmm.Parameters.AddWithValue("@UserId", userId);
                            cmm.ExecuteNonQuery();
                        }
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        MessageBox.Show("Successfully deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}