using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O48WRX_RESTFULCLIENT.Classes
{
    class Processors
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

        public Processors()
        {

        }

        public Processors(string manufacturer, string model, string clock, int price)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Clock = clock;
            this.Price = price;
        }


    }
}
