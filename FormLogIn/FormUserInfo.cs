using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FormLogIn
{
    public class UserInfo
    {
        public required string UserName { get; set; } 
        public required string FullName { get; set; }
        public required string BirthDay { get; set; }
        public required string Email { get; set; }
    }

    public partial class FormUserInfo : Form
    {
        public FormUserInfo(string response)
        {
            InitializeComponent();
            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(response);

            textBox_Username.Text = userInfo.UserName;
            textBox_Fullname.Text = userInfo.FullName;
            textBox_Birthday.Text = DateTime.Parse(userInfo.BirthDay).ToString("yyyy-MM-dd");
            textBox_Email.Text = userInfo.Email;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

