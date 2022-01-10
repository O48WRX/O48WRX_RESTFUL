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
    public partial class OrderedForm : Form
    {
        RestClient client = null;
        private string AdminToken = null;
        public TokenTransfer TransferToken;
        public OrderedForm()
        {
            InitializeComponent();
            TransferToken += new TokenTransfer(SetToken);
        }
        public void SetToken(string token)
        {
            AdminToken = token;
        }

        public void Orders2Grid()
        {
            client = new RestClient(string.Format("http://{0}:{1}/ordered", Form1.server, Form1.port));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<Ordered>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            List<Ordered> orders = new JsonSerializer().Deserialize<List<Ordered>>(response);
            ORD_GRID.DataSource = orders;
        }

        private void ORD_GRID_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ORD_IDBOX.Text = ORD_GRID.Rows[e.RowIndex].Cells[0].Value.ToString();
            ORD_USERID.Text = ORD_GRID.Rows[e.RowIndex].Cells[1].Value.ToString();
            ORD_PROCID.Text = ORD_GRID.Rows[e.RowIndex].Cells[2].Value.ToString();
            ORD_VGAID.Text = ORD_GRID.Rows[e.RowIndex].Cells[3].Value.ToString();
            ORD_PSUID.Text = ORD_GRID.Rows[e.RowIndex].Cells[4].Value.ToString();
            ORD_RAMID.Text = ORD_GRID.Rows[e.RowIndex].Cells[5].Value.ToString();
            ORD_MOBOID.Text = ORD_GRID.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void ORD_CREATE_Click(object sender, EventArgs e)
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

            client = new RestClient(string.Format("http://{0}:{1}/addorder/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port));
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                user_id = int.Parse(ORD_USERID.Text),
                processor_id = int.Parse(ORD_PROCID.Text),
                vga_id = int.Parse(ORD_VGAID.Text),
                psu_id = int.Parse(ORD_PSUID.Text),
                ram_id = int.Parse(ORD_RAMID.Text),
                mobo_id = int.Parse(ORD_MOBOID.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Orders2Grid();
        }

        private void ORD_UPDATE_Click(object sender, EventArgs e)
        {
            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            if (ORD_IDBOX.Text == "" || ORD_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/updateorder/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(ORD_IDBOX.Text)));
            var request = new RestRequest(Method.PUT);

            request.RequestFormat = DataFormat.Json;

            //TODO: Ha TextBoxok üresek akkor a cella értékeit használni.
            //Vagy nem lehet üres mezőkkel updatelni.
            request.AddJsonBody(new
            {
                user_id = int.Parse(ORD_USERID.Text),
                processor_id = int.Parse(ORD_PROCID.Text),
                vga_id = int.Parse(ORD_VGAID.Text),
                psu_id = int.Parse(ORD_PSUID.Text),
                ram_id = int.Parse(ORD_RAMID.Text),
                mobo_id = int.Parse(ORD_MOBOID.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Orders2Grid();
        }

        private void ORD_DELETE_Click(object sender, EventArgs e)
        {
            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            if (ORD_IDBOX.Text == "" || ORD_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/delorder/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(ORD_IDBOX.Text)));
            var request = new RestRequest(Method.DELETE);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Orders2Grid();
        }
    }
}
