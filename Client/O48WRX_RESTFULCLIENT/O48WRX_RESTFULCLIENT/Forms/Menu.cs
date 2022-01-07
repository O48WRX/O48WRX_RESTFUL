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

namespace O48WRX_RESTFULCLIENT.Forms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            label1.Text = string.Format("Üdvözöljük {0} a számítástechnikai boltban!", Form1.userloggedin.Username);
        }

        private void MENU_USERS_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }
    }
}
