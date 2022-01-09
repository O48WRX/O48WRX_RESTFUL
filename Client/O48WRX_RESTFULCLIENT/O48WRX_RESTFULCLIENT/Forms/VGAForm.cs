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
    public partial class VGAForm : Form
    {
        RestClient client = null;
        private string AdminToken = null;
        public TokenTransfer TransferToken;
        public VGAForm()
        {
            InitializeComponent();
            VGA2Grid();
            TransferToken += new TokenTransfer(SetToken);
        }

        public void VGA2Grid()
        {
            client = new RestClient(string.Format("http://{0}:{1}/vga", Form1.server, Form1.port));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<VGA>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            List<VGA> processors = new JsonSerializer().Deserialize<List<VGA>>(response);
            VGA_Grid.DataSource = processors;
        }

        public void SetToken(string token)
        {
            AdminToken = token;
        }

        private void VGA_Create_Click(object sender, EventArgs e)
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

            client = new RestClient(string.Format("http://{0}:{1}/addvga/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port));
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                manufacturer = VGA_MANUBOX.Text,
                model = VGA_MODELBOX.Text,
                vram = int.Parse(VGA_VRAMBOX.Text),
                clock = VGA_CLOCKBOX.Text,
                price = int.Parse(VGA_CLOCKBOX.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            VGA2Grid();
        }

        private void VGA_Update_Click(object sender, EventArgs e)
        {
            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            if (VGA_IDBOX.Text == "" || VGA_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/updatevga/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(VGA_IDBOX.Text)));
            var request = new RestRequest(Method.PUT);

            request.RequestFormat = DataFormat.Json;

            //TODO: Ha TextBoxok üresek akkor a cella értékeit használni.
            //Vagy nem lehet üres mezőkkel updatelni.
            request.AddJsonBody(new
            {
                manufacturer = VGA_MANUBOX.Text,
                model = VGA_MODELBOX.Text,
                vram = int.Parse(VGA_VRAMBOX.Text),
                clock = VGA_CLOCKBOX.Text,
                price = int.Parse(VGA_PRICEBOX.Text)
            });

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            VGA2Grid();
        }

        private void VGA_Delete_Click(object sender, EventArgs e)
        {
            if (AdminToken == null)
            {
                TokenDialog token = new TokenDialog(TransferToken);
                token.ShowDialog();
                return;
            }

            if (VGA_IDBOX.Text == "" || VGA_IDBOX.Text == null)
            {
                MessageBox.Show("Az azonosító mező nem lehet üres!");
                return;
            }

            client = new RestClient(string.Format("http://{0}:{1}/delvga/{2}/6eeb08e18ea7ee9335ec2d46793ea1bd", Form1.server, Form1.port, int.Parse(VGA_IDBOX.Text)));
            var request = new RestRequest(Method.DELETE);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            VGA2Grid();
        }
    }
}
