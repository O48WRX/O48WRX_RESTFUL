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
    public partial class ORD_INFOForm : Form
    {
        RestClient client = null;
        public ORD_INFOForm()
        {
            InitializeComponent();
            ORDINFO2Box();
        }

        public void ORDINFO2Box()
        {
            client = new RestClient(string.Format("http://{0}:{1}/orderedINFO", Form1.server, Form1.port));
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                user_id = '1',
                processor_id = '1',
                vga_id = '1',
                psu_id = '1',
                ram_id = '1',
                mobo_id = '1'
            });

            var response = client.Execute<Object>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }

            Object orders = new JsonSerializer().Deserialize<Object>(response);
            ORDINFO_GRID.DataSource = orders;
        }
    }
}
