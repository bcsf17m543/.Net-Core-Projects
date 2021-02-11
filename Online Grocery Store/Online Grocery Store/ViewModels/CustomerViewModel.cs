using Online_Grocery_Store.Commands;
using Online_Grocery_Store.Models;
using Online_Grocery_Store.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Online_Grocery_Store.ViewModels
{
    class CustomerViewModel:BaseViewModel
    {
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand SignupCommand { get; set; }
       

        public CustomerViewModel()
        {
            LoginCommand = new DelegateCommand(Login, canLogin);
            SignupCommand = new DelegateCommand(SignUp, canSignup);
        }
        public void SignUp(object para)
        {
            List<object> objs = para as List<object>;
            string logstr = (objs[0] as TextBox).Text;
            string passwrd = (objs[1] as PasswordBox).Password;
            string phone = (objs[2] as TextBox).Text;
            if (ValidateCredentialsforSignUp(objs))
            {
                try
                {
                    CustomerServices cs = new CustomerServices();
                    long newPhone = System.Convert.ToInt64(phone);
                    bool IsSignUp = false;
                    cs.SignUpCust(logstr, passwrd, newPhone,ref IsSignUp);
                    if (IsSignUp)
                    {
                        TextBlock Errormsg = (objs[3] as TextBlock);
                        MessageBox.Show("Signup sucessfull");
                    }
                    else
                    {
                        TextBlock Errormsg = (objs[3] as TextBlock);
                        Errormsg.Text = "UserAlreadyExists";
                    }

                }
                catch(Exception ex)
                {
                    TextBlock Errormsg = (objs[3] as TextBlock);
                    Errormsg.Text =  ex.Message;
                }
                
               
            }
            else
            {
                TextBlock Errormsg = (objs[3] as TextBlock);
                Errormsg.Text = "Incorrect Input";
            }
        }
        public bool ValidateCredentialsforSignUp(List<object>objs)
        {

            string logstr = (objs[0] as TextBox).Text;
            string passwrd = (objs[1] as PasswordBox).Password;
            string phone = (objs[2] as TextBox).Text;

            if (logstr.Length > 50 || passwrd.Length > 8 || phone.Length<11 || phone.Length>11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool canSignup(object para)
        {
            try
            {
                List<object> objs = para as List<object>;
                string logstr = (objs[0] as TextBox).Text;
                string passwrd = (objs[1] as PasswordBox).Password;
                string phone = (objs[2] as TextBox).Text;
                if (string.IsNullOrEmpty(logstr) || string.IsNullOrEmpty(passwrd)||string.IsNullOrEmpty(phone))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (NullReferenceException exp)
            {
                return false;
            }
        }
        public bool canLogin(object para)
        {
            try
            {
                List<object> objs = para as List<object>;
                string logstr = (objs[0] as TextBox).Text;
                string passwrd = (objs[1] as PasswordBox).Password;
                if (string.IsNullOrEmpty(logstr) || string.IsNullOrEmpty(passwrd))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(NullReferenceException exp)
            {
                return false;
            }
        }
        public bool ValidateCredentialsforLogin(List<object> objs)
        {
            string logstr = (objs[0] as TextBox).Text;
            string passwrd = (objs[1] as PasswordBox).Password;
            if(logstr.Length>50 || passwrd.Length>8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Login(object para)
        {
            List<object> objs = para as List<object>;
            string logstr = (objs[0] as TextBox).Text;
            string passwrd = (objs[1] as PasswordBox).Password;
            CustomerServices ls = new CustomerServices();
            if (ValidateCredentialsforLogin(objs))
            {
                Customer c = ls.LoginCust(logstr, passwrd);
                if(string.IsNullOrEmpty(c.Name))
                {
                    TextBlock Errormsg = (objs[2] as TextBlock);
                    Errormsg.Text = "User Does not Exists";
                }
                else
                {
                    AdminServices adminServices = new AdminServices();
                    ObservableCollection<Product> items = adminServices.ViewProduct();
                    //CartView cartWin = new CartView(items);
                    //cartWin.Show();
                    SampleWindow Swin = new SampleWindow(items);
                    Swin.Show();

                }
              

            }
            else
            {
                TextBlock Errormsg = (objs[2] as TextBlock);
                Errormsg.Text = "Incorrect Input";
            }
           
        }

    }
}
