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

            if (AdminToken == "")
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
            }

            client = new RestClient(string.Format("http://{0}:{1}/user", Form1.server, Form1.port));
        }

        public void SetToken(string token)
        {
            AdminToken = token;
        }
    }
}
