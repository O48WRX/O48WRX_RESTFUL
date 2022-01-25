using O48WRX_RESTFULCLIENT.Classes;
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
using System.Threading;

namespace O48WRX_RESTFULCLIENT.Forms
{
    public delegate void TokenTransfer(string data);
    public partial class Users : Form
    {
        public TokenTransfer TransferToken;
        RestClient client = null;
        private string AdminToken = null;
        public Users()
        {
            InitializeComponent();
            Users2DataGrid();
            TransferToken += new TokenTransfer(SetToken);
        }

        private void Users2DataGrid()
        {
            client = new RestClient(string.Format("http://{0}:{1}/user", Form1.server, Form1.port));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<User>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            List<User> users = new JsonSerializer().Deserialize<List<User>>(response);
            USERS_Grid.DataSource = users;
        }

        private void USERS_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            USERS_IDBOX.Text = USERS_Grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            USERS_NameBox.Text = USERS_Grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            USERS_PwBox.Text = USERS_Grid.Rows[e.RowIndex].Cells[2].Value.ToString();
            USERS_IsAdmin.Text = USERS_Grid.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void USERS_Create_Click(object sender, EventArgs e)
        {
            if (Form1.userloggedin.IsAdmin == 0)
            {
                MessageBox.Show("Nincs jogosultsága ehhez a művelethez!");
                return;
            }

            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            int temp;
            if (!int.TryParse(USERS_IsAdmin.Text, out temp))
            {
                MessageBox.Show("Az IsAdmin nem lehet más mint számjegy!");
            }

            client = new RestClient(string.Format("http://{0}:{1}/adduser/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port));
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                username = USERS_NameBox.Text,
                password = USERS_PwBox.Text,
                isAdmin = int.Parse(USERS_IsAdmin.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Users2DataGrid();
        }

        public void SetToken(string token)
        {
            AdminToken = token;
        }

        private void USERS_Update_Click(object sender, EventArgs e)
        {
            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            if (USERS_IDBOX.Text == "" || USERS_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/updateuser/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(USERS_IDBOX.Text)));
            var request = new RestRequest(Method.PUT);

            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                username = USERS_NameBox.Text,
                password = USERS_PwBox.Text,
                isAdmin = int.Parse(USERS_IsAdmin.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Users2DataGrid();
        }

        private void USERS_Delete_Click(object sender, EventArgs e)
        {
            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            if (USERS_IDBOX.Text == "" || USERS_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/deluser/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(USERS_IDBOX.Text)));
            var request = new RestRequest(Method.DELETE);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Users2DataGrid();
        }
    }
}
