using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using O48WRX_RESTFULCLIENT.Classes;

namespace O48WRX_RESTFULCLIENT.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            REGFORM_HIDEPW.Image = O48WRX_RESTFULCLIENT.Properties.Resources.closed;
            REGFORM_PASSWORD.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void REGFORM_HIDEPW_Click(object sender, EventArgs e)
        {
            if (REGFORM_PASSWORD.PasswordChar == '\0')
            {
                REGFORM_HIDEPW.Image = O48WRX_RESTFULCLIENT.Properties.Resources.closed;
                REGFORM_PASSWORD.PasswordChar = '*';
                return;
            }
            REGFORM_HIDEPW.Image = O48WRX_RESTFULCLIENT.Properties.Resources.open;
            REGFORM_PASSWORD.PasswordChar = '\0';
        }

        private void REGFORM_REG_Click(object sender, EventArgs e)
        {
            if (REGFORM_PASSWORD.Text == "")
            {
                MessageBox.Show("A jelszó mező nincs kitöltve!");
                return;
            }
            if (REGFORM_USERNAME.Text == "")
            {
                MessageBox.Show("A felhasználónév mező nincs kitöltve!");
            }
            RestClient client = new RestClient(String.Format("http://{0}:{1}/adduser/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port));
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                username = REGFORM_USERNAME.Text,
                password = MD5Crypt.Encrypt(REGFORM_PASSWORD.Text),
                isAdmin = 0
            });

            var response = client.Execute(request);
            //MessageBox.Show(MD5Crypt.Decrypt(MD5Crypt.Encrypt(REGFORM_PASSWORD.Text)));

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }
            MessageBox.Show("Successful registration!");
        }
    }
}
