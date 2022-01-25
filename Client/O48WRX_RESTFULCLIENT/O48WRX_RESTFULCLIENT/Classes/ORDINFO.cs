using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O48WRX_RESTFULCLIENT.Classes
{
    class ORDINFO
    {
        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        private string processor_model;

        public string Processor_model
        {
            get { return processor_model; }
            set { processor_model = value; }
        }

        private string vga_model;

        public string VGA_model
        {
            get { return vga_model; }
            set { vga_model = value; }
        }

        private string psu_model;

        public string PSU_model
        {
            get { return psu_model; }
            set { psu_model = value; }
        }

        private string ram_model;

        public string RAM_model
        {
            get { return ram_model; }
            set { ram_model = value; }
        }

        private string mobo_model;

        public string MOBO_model
        {
            get { return mobo_model; }
            set { mobo_model = value; }
        }

        public ORDINFO()
        {

        }

        public ORDINFO(string username, string processor, string vga, string psu, string ram, string mobo)
        {
            this.User = username;
            this.Processor_model = processor;
            this.VGA_model = vga;
            this.PSU_model = psu;
            this.RAM_model = ram;
            this.MOBO_model = mobo;
        }




    }
}
