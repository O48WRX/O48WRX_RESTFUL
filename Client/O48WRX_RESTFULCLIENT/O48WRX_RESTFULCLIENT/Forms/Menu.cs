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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            label1.Text = string.Format("Üdvözöljük {0} a számítástechnikai boltban!", Form1.userloggedin.Username);
        }

        private void MENU_USERS_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }

        private void MENU_PROCESSOR_Click(object sender, EventArgs e)
        {
            ProcessorForm processors = new ProcessorForm();
            processors.Show();
        }

        private void MENU_VGA_Click(object sender, EventArgs e)
        {
            VGAForm vga = new VGAForm();
            vga.Show();
        }

        private void MENU_PSU_Click(object sender, EventArgs e)
        {
            PSUForm psus = new PSUForm();
            psus.Show();
        }

        private void MENU_RAM_Click(object sender, EventArgs e)
        {
            RAMForm ram = new RAMForm();
            ram.Show();
        }

        private void MENU_MOBO_Click(object sender, EventArgs e)
        {
            MOBOForm mobos = new MOBOForm();
            mobos.Show();
        }

        private void MENU_ORDERED_Click(object sender, EventArgs e)
        {
            OrderedForm orders = new OrderedForm();
            orders.Show();
        }
    }
}
