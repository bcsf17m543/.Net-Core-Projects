using Online_Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Online_Grocery_Store.Views
{
    /// <summary>
    /// Interaction logic for ReceiptView.xaml
    /// </summary>
    public partial class ReceiptView : Window
    {
        public ReceiptView(ObservableCollection<Product> items,int totalamm)
        {
            InitializeComponent();

            ListofItems.ItemsSource = items;
            Ammount.Text = totalamm.ToString();
        }
    }
}
