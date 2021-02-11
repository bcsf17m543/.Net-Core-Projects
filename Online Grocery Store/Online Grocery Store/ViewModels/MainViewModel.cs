using Online_Grocery_Store.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Online_Grocery_Store.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private BaseViewModel selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public ICommand UpdateViewCommand { get; set; }
        public MainViewModel()
        {
            UpdateViewCommand = new DelegateCommand(ViewSelector, canExecute);
            selectedViewModel = new HomeViewModel();
        }

        bool canExecute(object o)
        {
            return true;
        }

        void ViewSelector(object o)
        {

            if ((o as string).Equals("Admin"))
            {
                SelectedViewModel = new AdminViewModel();
            }
            else if ((o as string).Equals("Customer"))
            {
                SelectedViewModel = new CustomerViewModel();
            }
            else if ((o as string).Equals("Home"))
            {
                SelectedViewModel = new HomeViewModel();
            }
            else if ((o as string).Equals("LogOut"))
            {
                SelectedViewModel = new HomeViewModel();
            }
        }
    }
}
