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
        //TODO: Nem szabad hogy nem létező ID-kkel hívják meg a CRUD-ot.
        RestClient client = null;
        private string AdminToken = null;
        public TokenTransfer TransferToken;

        public static Ordered order1 = null;
        public OrderedForm()
        {
            InitializeComponent();
            TransferToken += new TokenTransfer(SetToken);
            Orders2Grid();
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

            int temp;
            if (!int.TryParse(ORD_PROCID.Text, out temp) || !int.TryParse(ORD_VGAID.Text, out temp) || !int.TryParse(ORD_PSUID.Text, out temp) || !int.TryParse(ORD_RAMID.Text, out temp) || !int.TryParse(ORD_MOBOID.Text, out temp))
            {
                MessageBox.Show("A mezőket (processzor id, vga id, psu id, ram id, mobo id nem lehet más mint számjegy!)");
                return;
            }

            if (!TestIDExistence())
            {
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

            int temp;
            if (!int.TryParse(ORD_USERID.Text, out temp) || !int.TryParse(ORD_PROCID.Text, out temp) || !int.TryParse(ORD_VGAID.Text, out temp) || !int.TryParse(ORD_PSUID.Text, out temp) || !int.TryParse(ORD_RAMID.Text, out temp) || !int.TryParse(ORD_MOBOID.Text, out temp))
            {
                MessageBox.Show("A mezőket (id, processzor id, vga id, psu id, ram id, mobo id nem lehet más mint számjegy!)");
                return;
            }

            if (!TestIDExistence())
            {
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

            int temp;
            if (!int.TryParse(ORD_USERID.Text, out temp))
            {
                MessageBox.Show("Az ID mező nem lehet nem szám!");
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

        private void ORD_INFO_Click(object sender, EventArgs e)
        {
            order1 = new Ordered(int.Parse(ORD_IDBOX.Text), int.Parse(ORD_USERID.Text), int.Parse(ORD_PROCID.Text), int.Parse(ORD_VGAID.Text), int.Parse(ORD_PSUID.Text), int.Parse(ORD_RAMID.Text), int.Parse(ORD_MOBOID.Text));
            ORD_INFOForm form1 = new ORD_INFOForm();
            form1.Show();

        }

        public bool TestIDExistence()
        {
            RestClient client1 = new RestClient(string.Format("http://{0}:{1}/user/{2}", Form1.server, Form1.port, int.Parse(ORD_USERID.Text)));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client1.Execute<List<User>>(request);

            List<User> users = new JsonSerializer().Deserialize<List<User>>(response);

            if (response.StatusCode != System.Net.HttpStatusCode.OK || users.Count == 0)
            {
                MessageBox.Show("Ilyen azonosítójú felhasználó nem létezik!");
                return false;
            }

            RestClient client2 = new RestClient(string.Format("http://{0}:{1}/processor/{2}", Form1.server, Form1.port, int.Parse(ORD_PROCID.Text)));
            request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response1 = client2.Execute<List<Processors>>(request);

            List<Processors> processors = new JsonSerializer().Deserialize<List<Processors>>(response1);

            if (response1.StatusCode != System.Net.HttpStatusCode.OK || processors.Count == 0)
            {
                MessageBox.Show("Ilyen azonosítójú processzor nem létezik!");
                return false;
            }

            RestClient client3  = new RestClient(string.Format("http://{0}:{1}/vga/{2}", Form1.server, Form1.port, int.Parse(ORD_VGAID.Text)));
            request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response2 = client3.Execute<List<VGA>>(request);

            List<VGA> vgas = new JsonSerializer().Deserialize<List<VGA>>(response2);

            if (response2.StatusCode != System.Net.HttpStatusCode.OK || vgas.Count == 0)
            {
                MessageBox.Show("Ilyen azonosítójú VGA nem létezik!");
                return false;
            }

            RestClient client4  = new RestClient(string.Format("http://{0}:{1}/psu/{2}", Form1.server, Form1.port, int.Parse(ORD_PSUID.Text)));
            request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response3 = client4.Execute<List<PSU>>(request);

            List<PSU> psus = new JsonSerializer().Deserialize<List<PSU>>(response3);

            if (response3.StatusCode != System.Net.HttpStatusCode.OK || psus.Count == 0)
            {
                MessageBox.Show("Ilyen azonosítójú tápegység nem létezik!");
                return false;
            }

            RestClient client5  = new RestClient(string.Format("http://{0}:{1}/ram/{2}", Form1.server, Form1.port, int.Parse(ORD_RAMID.Text)));
            request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response4 = client5.Execute<List<RAM>>(request);

            List<RAM> rams = new JsonSerializer().Deserialize<List<RAM>>(response4);

            if (response4.StatusCode != System.Net.HttpStatusCode.OK || rams.Count == 0)
            {
                MessageBox.Show("Ilyen azonosítójú RAM nem létezik!");
                return false;
            }

            RestClient client6  = new RestClient(string.Format("http://{0}:{1}/mobo/{2}", Form1.server, Form1.port, int.Parse(ORD_MOBOID.Text)));
            request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response5 = client6.Execute<List<Mobo>>(request);

            List<Mobo> mobos = new JsonSerializer().Deserialize<List<Mobo>>(response5);

            if (response5.StatusCode != System.Net.HttpStatusCode.OK || mobos.Count == 0)
            {
                MessageBox.Show("Ilyen azonosítójú Alaplap nem létezik!");
                return false;
            }

            return true;
        }
    }
}
