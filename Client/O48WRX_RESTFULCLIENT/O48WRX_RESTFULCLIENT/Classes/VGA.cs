using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O48WRX_RESTFULCLIENT.Classes
{
    class VGA
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string manufacturer;

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int vram;

        public int Vram
        {
            get { return vram; }
            set { vram = value; }
        }

        private string clock;

        public string Clock
        {
            get { return clock; }
            set { clock = value; }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public VGA()
        {

        }

        public VGA(int id, string manufacturer, string model, int vram, string clock, int price)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Vram = vram;
            this.Clock = clock;
            this.Price = price;
        }




    }
}
