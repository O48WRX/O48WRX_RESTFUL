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
    public partial class MOBOForm : Form
    {
        RestClient client = null;
        private string AdminToken = null;
        public TokenTransfer TransferToken;
        public MOBOForm()
        {
            InitializeComponent();
            TransferToken += new TokenTransfer(SetToken);
            MOBO2Grid();
        }

        public void SetToken(string token)
        {
            AdminToken = token;
        }

        public void MOBO2Grid()
        {
            client = new RestClient(string.Format("http://{0}:{1}/mobo", Form1.server, Form1.port));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<Mobo>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            List<Mobo> mobos = new JsonSerializer().Deserialize<List<Mobo>>(response);
            MOBO_GRID.DataSource = mobos;
        }

        private void MOBO_Create_Click(object sender, EventArgs e)
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
            if (!int.TryParse(MOBO_RAMSOCKETS.Text, out temp) || !int.TryParse(MOBO_PRICEBOX.Text, out temp))
            {
                MessageBox.Show("A mezőknek (RAM foglalatok, ár) számjegynek kell lennie!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/addmobo/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port));
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                manufacturer = MOBO_MANUBOX.Text,
                model = MOBO_MODELBOX.Text,
                ram_type = MOBO_RAMTYPE.Text,
                ram_sockets = int.Parse(MOBO_RAMSOCKETS.Text),
                price = int.Parse(MOBO_PRICEBOX.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            MOBO2Grid();
        }

        private void MOBO_Update_Click(object sender, EventArgs e)
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

            if (MOBO_IDBOX.Text == "" || MOBO_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            int temp;
            if (!int.TryParse(MOBO_IDBOX.Text, out temp) ||!int.TryParse(MOBO_RAMSOCKETS.Text, out temp) || !int.TryParse(MOBO_PRICEBOX.Text, out temp))
            {
                MessageBox.Show("A mezőknek (ID, RAM foglalatok, ár) számjegynek kell lennie!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/updatemobo/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(MOBO_IDBOX.Text)));
            var request = new RestRequest(Method.PUT);

            request.RequestFormat = DataFormat.Json;

            //TODO: Ha TextBoxok üresek akkor a cella értékeit használni.
            //Vagy nem lehet üres mezőkkel updatelni.
            request.AddJsonBody(new
            {
                manufacturer = MOBO_MANUBOX.Text,
                model = MOBO_MODELBOX.Text,
                ram_type = MOBO_RAMTYPE.Text,
                ram_sockets = int.Parse(MOBO_RAMSOCKETS.Text),
                price = int.Parse(MOBO_PRICEBOX.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            MOBO2Grid();
        }

        private void MOBO_Delete_Click(object sender, EventArgs e)
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

            if (MOBO_IDBOX.Text == "" || MOBO_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            int temp;
            if (!int.TryParse(MOBO_IDBOX.Text, out temp))
            {
                MessageBox.Show("Az azonosító mezőnek számjegynek kell lennie!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/delmobo/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(MOBO_IDBOX.Text)));
            var request = new RestRequest(Method.DELETE);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            MOBO2Grid();
        }

        private void MOBO_GRID_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MOBO_IDBOX.Text = MOBO_GRID.Rows[e.RowIndex].Cells[0].Value.ToString();
            MOBO_MANUBOX.Text = MOBO_GRID.Rows[e.RowIndex].Cells[1].Value.ToString();
            MOBO_MODELBOX.Text = MOBO_GRID.Rows[e.RowIndex].Cells[2].Value.ToString();
            MOBO_RAMTYPE.Text = MOBO_GRID.Rows[e.RowIndex].Cells[3].Value.ToString();
            MOBO_RAMSOCKETS.Text = MOBO_GRID.Rows[e.RowIndex].Cells[4].Value.ToString();
            MOBO_PRICEBOX.Text = MOBO_GRID.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
