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
    public partial class RAMForm : Form
    {
        RestClient client = null;
        private string AdminToken = null;
        public TokenTransfer TransferToken;
        public RAMForm()
        {
            InitializeComponent();
            TransferToken += new TokenTransfer(SetToken);
            Ram2Grid();
        }
        public void SetToken(string token)
        {
            AdminToken = token;
        }

        public void Ram2Grid()
        {
            client = new RestClient(string.Format("http://{0}:{1}/ram", Form1.server, Form1.port));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<RAM>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            List<RAM> ram = new JsonSerializer().Deserialize<List<RAM>>(response);
            RAM_GRID.DataSource = ram;
        }

        private void RAM_Create_Click(object sender, EventArgs e)
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
            if (!int.TryParse(RAM_PRICEBOX.Text, out temp))
            {
                MessageBox.Show("A mezőknek (ár) számjegynek kell lennie!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/addram/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port));
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;


            request.AddJsonBody(new
            {
                manufacturer = RAM_MANUBOX.Text,
                model = RAM_MODELBOX.Text,
                clock = RAM_CLOCKBOX.Text,
                capacity = RAM_CAPBOX.Text,
                price = int.Parse(RAM_PRICEBOX.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Ram2Grid();
        }

        private void RAM_Update_Click(object sender, EventArgs e)
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

            if (RAM_IDBOX.Text == "" || RAM_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            int temp;
            if (!int.TryParse(RAM_PRICEBOX.Text, out temp) || !int.TryParse(RAM_IDBOX.Text, out temp))
            {
                MessageBox.Show("A mezőknek (ár, azonosító) számjegynek kell lennie!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/updateram/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(RAM_IDBOX.Text)));
            var request = new RestRequest(Method.PUT);

            request.RequestFormat = DataFormat.Json;

            //TODO: Ha TextBoxok üresek akkor a cella értékeit használni.
            //Vagy nem lehet üres mezőkkel updatelni.
            request.AddJsonBody(new
            {
                manufacturer = RAM_MANUBOX.Text,
                model = RAM_MODELBOX.Text,
                clock = RAM_CLOCKBOX.Text,
                capacity = RAM_CAPBOX.Text,
                price = int.Parse(RAM_PRICEBOX.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Ram2Grid();
        }

        private void RAM_Delete_Click(object sender, EventArgs e)
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

            if (RAM_IDBOX.Text == "" || RAM_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            int temp;
            if (!int.TryParse(RAM_IDBOX.Text, out temp))
            {
                MessageBox.Show("A mezőknek (Azonosító) számjegynek kell lennie!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/delram/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(RAM_IDBOX.Text)));
            var request = new RestRequest(Method.DELETE);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            Ram2Grid();
        }

        private void RAM_GRID_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RAM_IDBOX.Text = RAM_GRID.Rows[e.RowIndex].Cells[0].Value.ToString();
            RAM_MANUBOX.Text = RAM_GRID.Rows[e.RowIndex].Cells[1].Value.ToString();
            RAM_MODELBOX.Text = RAM_GRID.Rows[e.RowIndex].Cells[2].Value.ToString();
            RAM_CLOCKBOX.Text = RAM_GRID.Rows[e.RowIndex].Cells[3].Value.ToString();
            RAM_CAPBOX.Text = RAM_GRID.Rows[e.RowIndex].Cells[4].Value.ToString();
            RAM_PRICEBOX.Text = RAM_GRID.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
