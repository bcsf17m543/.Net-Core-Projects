using Online_Grocery_Store.Models;
using Online_Grocery_Store.ViewModels;
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
    /// Interaction logic for SampleWindow.xaml
    /// </summary>
    public partial class SampleWindow : Window
    {
        public SampleWindow(ObservableCollection<Product> items)
        {
            InitializeComponent();
            SampleViewModel vm = new SampleViewModel();
            this.DataContext = vm;
            MyItems.ItemsSource = items;
            Myshopping.ItemsSource = vm.MyCart;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);

        }

        private void Logout_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
