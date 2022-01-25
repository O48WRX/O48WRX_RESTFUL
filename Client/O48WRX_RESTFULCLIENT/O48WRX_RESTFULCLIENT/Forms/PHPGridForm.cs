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
    public partial class PHPGridForm : Form
    {
        RestClient client = null;
        public PHPGridForm()
        {
            InitializeComponent();
            PHPOrders2Grid();
        }

        public void PHPOrders2Grid()
        {
            client = new RestClient(string.Format("http://{0}:{1}/orderedPHP", Form1.server, Form1.port));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<Ordered>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription);
                return;
            }

            List<Ordered> orders = new JsonSerializer().Deserialize<List<Ordered>>(response);
            PHPFORM_GRID.DataSource = orders;
        }
 
        private void PHPFORM_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
