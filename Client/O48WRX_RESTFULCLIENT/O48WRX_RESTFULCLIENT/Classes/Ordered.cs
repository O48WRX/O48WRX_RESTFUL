using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O48WRX_RESTFULCLIENT.Classes
{
    class Ordered
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int user_id;

        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private int processor_id;

        public int Processor_id
        {
            get { return processor_id; }
            set { processor_id = value; }
        }

        private int vga_id;

        public int VGA_id
        {
            get { return vga_id; }
            set { vga_id = value; }
        }

        private int psu_id;

        public int PSU_id
        {
            get { return psu_id; }
            set { psu_id = value; }
        }

        private int ram_id;

        public int RAM_id
        {
            get { return ram_id; }
            set { ram_id = value; }
        }

        private int mobo_id;

        public int MOBO_id
        {
            get { return mobo_id; }
            set { mobo_id = value; }
        }

        public Ordered()
        {

        }

        public Ordered(int id, int user_id, int processor_id, int vga_id, int psu_id, int ram_id, int mobo_id)
        {
            this.Id = id;
            this.User_id = user_id;
            this.Processor_id = processor_id;
            this.VGA_id = vga_id;
            this.PSU_id = psu_id;
            this.RAM_id = ram_id;
            this.MOBO_id = mobo_id;
        }
    }
}
