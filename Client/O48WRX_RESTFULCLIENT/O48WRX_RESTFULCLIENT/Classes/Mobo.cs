using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O48WRX_RESTFULCLIENT.Classes
{
    class Mobo
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


        private string ram_type;

        public string Ram_type
        {
            get { return ram_type; }
            set { ram_type = value; }
        }

        private int ram_sockets;

        public int Ram_sockets
        {
            get { return ram_sockets; }
            set { ram_sockets = value; }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Mobo()
        {

        }

        public Mobo(int id, string manufacturer, string model, string ram_type, int ram_sockets, int price)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Ram_type = ram_type;
            this.Ram_sockets = ram_sockets;
            this.Price = price;
        }
    }
}
