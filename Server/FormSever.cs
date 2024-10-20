using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

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
        private void HandleClient(TcpClient client)
        { 
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[4096];
            int byteCount;
            try
            { 
                while ((byteCount = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string request = Encoding.Unicode.GetString(buffer, 0, byteCount);
                    string response = HandleRequest(request);
                    byte[] responseData = Encoding.Unicode.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);
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
        private string HandleRequest(string request)
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

            return "Unknown request";
           
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