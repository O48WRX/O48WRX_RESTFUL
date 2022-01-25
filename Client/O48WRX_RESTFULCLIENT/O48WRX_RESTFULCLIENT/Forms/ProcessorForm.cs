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
    public partial class ProcessorForm : Form
    {
        private string AdminToken = null;
        public TokenTransfer TransferToken;
        RestClient client = null;
        public ProcessorForm()
        {
            InitializeComponent();
            Proc2Grid();
            TransferToken += new TokenTransfer(SetToken);
        }
        
        public void Proc2Grid()
        {
            client = new RestClient(string.Format("http://{0}:{1}/processor", Form1.server, Form1.port));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<Processors>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            List<Processors> processors = new JsonSerializer().Deserialize<List<Processors>>(response);
            PROC_GRID.DataSource = processors;
        }

        private void PROC_GRID_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PROC_IDBOX.Text = PROC_GRID.Rows[e.RowIndex].Cells[0].Value.ToString();
            PROC_MANUBOX.Text = PROC_GRID.Rows[e.RowIndex].Cells[1].Value.ToString();
            PROC_MODELBOX.Text = PROC_GRID.Rows[e.RowIndex].Cells[2].Value.ToString();
            PROC_CLOCKBOX.Text = PROC_GRID.Rows[e.RowIndex].Cells[3].Value.ToString();
            PROC_PRICEBOX.Text = PROC_GRID.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void PROC_Create_Click(object sender, EventArgs e)
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
            if (!int.TryParse(PROC_PRICEBOX.Text, out temp))
            {
                MessageBox.Show("Az órajel csak szám lehet!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/addprocessor/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port));
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                manufacturer = PROC_MANUBOX.Text,
                model = PROC_MODELBOX.Text,
                clock = PROC_CLOCKBOX.Text,
                price = int.Parse(PROC_PRICEBOX.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Proc2Grid();
        }

        private void PROC_Update_Click(object sender, EventArgs e)
        {
            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            if (PROC_IDBOX.Text == "" || PROC_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            int temp;
            if (!int.TryParse(PROC_PRICEBOX.Text, out temp) || !int.TryParse(PROC_IDBOX.Text, out temp))
            {
                MessageBox.Show("Az órajel, azonosító csak szám lehet!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/updateprocessor/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(PROC_IDBOX.Text)));
            var request = new RestRequest(Method.PUT);

            request.RequestFormat = DataFormat.Json;

            //TODO: Ha TextBoxok üresek akkor a cella értékeit használni.
            //Vagy nem lehet üres mezőkkel updatelni.
            request.AddJsonBody(new
            {
                manufacturer = PROC_MANUBOX.Text,
                model = PROC_MODELBOX.Text,
                clock = PROC_CLOCKBOX.Text,
                price = int.Parse(PROC_PRICEBOX.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Proc2Grid();
        }

        private void PROC_Delete_Click(object sender, EventArgs e)
        {
            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            if (PROC_IDBOX.Text == "" || PROC_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            int temp;
            if (!int.TryParse(PROC_IDBOX.Text, out temp))
            {
                MessageBox.Show("Az azonosító csak szám lehet!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/delprocessor/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(PROC_IDBOX.Text)));
            var request = new RestRequest(Method.DELETE);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Proc2Grid();
        }

        public void SetToken(string token)
        {
            AdminToken = token;
        }
    }
}
