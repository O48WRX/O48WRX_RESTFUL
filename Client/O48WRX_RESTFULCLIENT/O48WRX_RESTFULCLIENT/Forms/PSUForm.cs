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
    public partial class PSUForm : Form
    {
        RestClient client = null;
        private string AdminToken = null;
        public TokenTransfer TransferToken;
        public PSUForm()
        {
            InitializeComponent();
            TransferToken += new TokenTransfer(SetToken);
            PSU2Grid();
        }
        public void SetToken(string token)
        {
            AdminToken = token;
        }
        
        public void PSU2Grid()
        {
            client = new RestClient(string.Format("http://{0}:{1}/psu", Form1.server, Form1.port));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<PSU>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            List<PSU> psus = new JsonSerializer().Deserialize<List<PSU>>(response);
            PSU_Grid.DataSource = psus;
        }

        private void PSU_Create_Click(object sender, EventArgs e)
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

            client = new RestClient(string.Format("http://{0}:{1}/addpsu/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port));
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                manufacturer = PSU_MANUBOX.Text,
                model = PSU_MODELBOX.Text,
                performance = PSU_PERFBOX.Text,
                price = int.Parse(PSU_PRICEBOX.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            PSU2Grid();
        }

        private void PSU_Update_Click(object sender, EventArgs e)
        {
            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            if (PSU_IDBOX.Text == "" || PSU_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/updatepsu/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(PSU_IDBOX.Text)));
            var request = new RestRequest(Method.PUT);

            request.RequestFormat = DataFormat.Json;

            //TODO: Ha TextBoxok üresek akkor a cella értékeit használni.
            //Vagy nem lehet üres mezőkkel updatelni.
            request.AddJsonBody(new
            {
                manufacturer = PSU_MANUBOX.Text,
                model = PSU_MODELBOX.Text,
                performance = PSU_PERFBOX.Text,
                price = int.Parse(PSU_PRICEBOX.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            PSU2Grid();
        }

        private void PSU_Delete_Click(object sender, EventArgs e)
        {
            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            if (PSU_IDBOX.Text == "" || PSU_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/delpsu/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(PSU_IDBOX.Text)));
            var request = new RestRequest(Method.DELETE);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            PSU2Grid();
        }

        private void PSU_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PSU_IDBOX.Text = PSU_Grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            PSU_MANUBOX.Text = PSU_Grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            PSU_MODELBOX.Text = PSU_Grid.Rows[e.RowIndex].Cells[2].Value.ToString();
            PSU_PERFBOX.Text = PSU_Grid.Rows[e.RowIndex].Cells[3].Value.ToString();
            PSU_PRICEBOX.Text = PSU_Grid.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
