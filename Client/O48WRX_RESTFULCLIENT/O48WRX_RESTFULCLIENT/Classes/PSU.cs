using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O48WRX_RESTFULCLIENT.Classes
{
    class PSU
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

        private string performance;

        public string Performance
        {
            get { return performance; }
            set { performance = value; }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public PSU()
        {

        }

        public PSU(int id, string manufacturer, string model, string performance, int price)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Performance = performance;
            this.Price = price;
        }

    }
}
