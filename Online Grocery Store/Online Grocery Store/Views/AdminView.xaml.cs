using Online_Grocery_Store.Models;
using Online_Grocery_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Online_Grocery_Store.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        public AdminView()
        {
            InitializeComponent();
            this.DataContext = new AdminViewModel();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new HomeView();
            
        }

        private void LogOut_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new HomeView();

        }
    }
}
