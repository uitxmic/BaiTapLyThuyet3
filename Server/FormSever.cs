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
using Newtonsoft.Json;

namespace Server
{
    public partial class FormServer : Form
    {
        static string ConnectString = @"Data Source=localhost;Initial Catalog=Bai_tap_ly_thuyet_3;Integrated Security=True";
        static TcpListener listener;
        static List<TcpClient> clients = new List<TcpClient>();

        public FormServer()
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
                this.Invoke((MethodInvoker)delegate
                {
                    richTextBox1.AppendText($"New connection from {clientIP}!\n");
                });
                Task.Run(() => HandleClient(client));
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int byteCount;

            try
            {
                while ((byteCount = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string request = Encoding.ASCII.GetString(buffer, 0, byteCount);
                    string response = HandleRequest(request);
                    byte[] responseData = Encoding.ASCII.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);
                }
                clients.Remove(client);
                client.Close();
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
            }
        }

        private string HandleRequest(string request)
        {
            try
            {
                var jsonRequest = JsonConvert.DeserializeObject<Dictionary<string, string>>(request);
                string action = jsonRequest["action"];
                string username = jsonRequest["username"];
                string password = jsonRequest["password"];

                if (action == "LOGIN")
                {
                    return ResponseFromDatabase(username, password);
                }

                if (action == "REGISTER")
                {
                    return "Register functionality not implemented yet.";
                }

                return "{\"message\": \"Unknown request\"}";
            }
            catch (Exception ex)
            {
                return "{\"message\": \"Server error\"}";
            }
        }

        private string ResponseFromDatabase(string username, string password)
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

                                var userInfo = new
                                {
                                    UserName = userName,
                                    FullName = fullName,
                                    BirthDay = birthDay.ToString("yyyy-MM-dd"),
                                    Email = email
                                };

                                string jsonResponse = JsonConvert.SerializeObject(userInfo);
                                return jsonResponse;
                            }
                            else
                            {
                                return "{\"message\": \"Invalid username or password\"}";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "{\"message\": \"Error: " + ex.Message + "\"}";
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
            if (MessageBox.Show("Are you sure to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                    int userId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    using (SqlConnection conn = new SqlConnection(ConnectString))
                    {
                        conn.Open();
                        using (SqlCommand cmm = new SqlCommand("DELETE FROM USERS WHERE UserId=@UserId", conn))
                        {
                            cmm.Parameters.AddWithValue("@UserId", userId);
                            cmm.ExecuteNonQuery();
                        }
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        MessageBox.Show("Successfully deleted.");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
