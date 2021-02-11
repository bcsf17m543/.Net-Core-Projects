using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
namespace Online_Grocery_Store.Models
{
    public class Product:INotifyPropertyChanged
    {
        private int id;
        private string prodname;
        private int price;
        private int qty;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChange(string propname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                this.NotifyChange("Id");
            }
        }
        public string Prodname
        {
            get
            {
                return prodname;
            }
            set
            {
                prodname = value;
                this.NotifyChange("Product Name");

            }
        }
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                this.NotifyChange("Price");
            }
        }
        public int Qty
        {
            get
            {
                return qty;
            }
            set
            {
                qty = value;
                this.NotifyChange("Quty");
            }
        }
        public Product()
        {
            this.id = default;
            this.prodname = default;
            this.price =default;
            this.qty = default;
        }
        public Product(Product p)
        {
            this.id = p.id;
            this.prodname = p.prodname;
            this.price = p.price;
            this.qty = p.qty;
        }
        public override string ToString()
        {
           
            string line = String.Format("{0} {1} {2} {3}", Id, Prodname, Price, Qty);
            return line;
        }


    }
}
