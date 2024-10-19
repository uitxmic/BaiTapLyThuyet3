using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FormSever : Form
    {
        string ConnectString = @"Data Source=localhost;Initial Catalog=Bai_tap_ly_thuyet_3;Integrated Security=True";
        private static TcpListener listener;
        private static List<TcpClient> clients = new List<TcpClient>();
        public FormSever()
        {
            InitializeComponent();
            Task.Run(() => InitializeSocket());
        }
        private static void InitializeSocket()
        {
            listener = new TcpListener(IPAddress.Any, 5555);
            listener.Start();
            MessageBox.Show("Server started...");
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                clients.Add(client);
                MessageBox.Show("New client connected...");
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }
        private static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int byteCount;

            while ((byteCount = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string request = Encoding.ASCII.GetString(buffer, 0, byteCount);
                MessageBox.Show("Received: " + request);
                string response = HandleRequest(request);
                byte[] responseData = Encoding.ASCII.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);
            }
            clients.Remove(client);
            client.Close();
        }
        private static string HandleRequest(string request)
        {
            if (request.StartsWith("LOGIN"))
            {
                return "Login successful";
            }
            else if (request.StartsWith("REGISTER"))
            {
                return "Register successful";
            }
            return "Unknown request";
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
                        MessageBox.Show("Successfully deleted.");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

    }
}