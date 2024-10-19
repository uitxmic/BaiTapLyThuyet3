using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class FormUserInfo : Form
    {
        public FormUserInfo(UserInfor userInfo)
        {
            InitializeComponent();
            textBox_Username.Text = userInfo.UserName;
            textBox_Fullname.Text = userInfo.FullName;
            textBox_DateofBirth.Text = userInfo.Birthday.ToString("yyyy-MM-dd");
            textBox_Email.Text = userInfo.Email;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
