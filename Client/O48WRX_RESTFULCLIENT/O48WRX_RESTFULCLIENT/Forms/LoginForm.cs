using O48WRX_RESTFULCLIENT.Classes;
using O48WRX_RESTFULCLIENT.Forms;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O48WRX_RESTFULCLIENT
{
    public partial class Form1 : Form
    {
        public static string server = "127.0.0.1";
        public static string port = "3000";
        public static User userloggedin;
        RestClient client = null;
        public Form1()
        {
            InitializeComponent();
            F1_PASSWORDBOX.PasswordChar = '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void F1_LOGIN_Click(object sender, EventArgs e)
        {
            client = new RestClient(string.Format("http://{0}:{1}/user", server, port));
            var request = new RestRequest(Method.GET);

            string tempusername = F1_NAMEBOX.Text;
            string temppassword = F1_PASSWORDBOX.Text;

            var response = client.Execute<List<User>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            var deserializer = new JsonDeserializer();
            var deserializedJSON = deserializer.Deserialize<List<User>>(response);

            for (int i = 0; i < deserializedJSON.Count; i++)
            {
                if (deserializedJSON[i].Username == tempusername && deserializedJSON[i].Password == temppassword || deserializedJSON[i].Password == MD5Crypt.Encrypt(temppassword))
                {
                    MessageBox.Show("Felhasználó megtalálva!");
                    userloggedin = new User(deserializedJSON[i].Id, deserializedJSON[i].Username, deserializedJSON[i].Password, deserializedJSON[i].IsAdmin);
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                    return;
                }
            }

            if (userloggedin == null)
            {
                MessageBox.Show("Helytelen bejelentkezési információk!");
                return;
            }
        }

        private void F1_REG_Click(object sender, EventArgs e)
        {
            RegistrationForm regform = new RegistrationForm();
            regform.ShowDialog();
        }
    }
}
