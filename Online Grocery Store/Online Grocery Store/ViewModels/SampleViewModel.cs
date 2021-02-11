using Online_Grocery_Store.Commands;
using Online_Grocery_Store.Models;
using Online_Grocery_Store.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Online_Grocery_Store.ViewModels
{
    class SampleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public int ID { get => iD; set { iD = value; OnPropertyChanged("ID"); } }
        public int Qty { get => qty; set { qty = value; OnPropertyChanged("Quantity"); } }
        public CustomerServices cusSer { get; set; }
        public ObservableCollection<Product> MyCart { get; set; }
        public DelegateCommand2 AddCommand { get; set; }
        public DelegateCommand2 PrintCommand { get; set; }
        public Action CloseAction { get; set; }
        public DelegateCommand2 FinishCommand { get; set; }
        private int qty;
        private int iD;
        private int total;
        public int Total{ get => total; set { total = value; OnPropertyChanged("Total"); } }

        public SampleViewModel()
        {
            cusSer = new CustomerServices();
            MyCart = cusSer.prods;
            AddCommand = new DelegateCommand2(Add, canAdd);
            PrintCommand = new DelegateCommand2(Receipt, canPrint);
            FinishCommand = new DelegateCommand2(Finish, canPrint);
        }
       public void Finish(object o)
        {
            CloseAction();
        }
        public bool canPrint(object o)
        {
            return true;
        }
        public void Add(object o)
        {
            if(cusSer.AddItem(ID, Qty))
            {
                MyCart = cusSer.prods;
                MessageBox.Show("Product Added Susessfully");
                                
            }
            else
            {
                MessageBox.Show("Product is not added\nthis could be because of\nNot enough quantity\nMaybe the id is incorrect");
            }
            Qty = 0;
            ID = 0;


           
        }

        public void Receipt(object o)
        {
            if(cusSer.prods.Count==0)
            {
                MessageBox.Show("You have nothing in your cart.\nPlease buy something for a receipt");
            }
            else
            {
                Total = cusSer.countTotal();
                ReceiptView Myreceipt = new ReceiptView(MyCart,Total);
                Myreceipt.Show();
            }

        }

     

      
        
        public bool canAdd(object o)
        {
            if (!string.IsNullOrEmpty(ID.ToString()) && ID!=0 && Qty!=0 &&
               !string.IsNullOrEmpty(Qty.ToString()) && !string.IsNullOrWhiteSpace(ID.ToString()) && !string.IsNullOrWhiteSpace(Qty.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
