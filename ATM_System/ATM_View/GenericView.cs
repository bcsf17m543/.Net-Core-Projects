using System;
using System.Collections.Generic;
using System.Text;
using ATM_BLL;
using ATM_BO;
using static System.Console;

namespace ATM_View
{
    public class GenericView
    {
        public void Login()
        {
            int tries = 3;
            while (tries > 0)
            {
                WriteLine("Enter Login:");
                string logi = ReadLine();
                WriteLine("Enter PinCode:");
                string code = ReadLine();
                if (code.Length != 5)
                {
                    WriteLine("Pincode must contain only 5 characters.");
                    tries--;
                    continue;
                }
                AdminBO adm = new AdminBO { Name = logi, Pincode = code };
                UserO usr = new UserO { Login = logi, Pincode = code };
                UserView usrv = new UserView();
                AdminView admv = new AdminView();
                if (admv.Search(adm))
                {
                    admv.Admin_Menu(); //Displays Admin Side and functionalities
                    return;
                }
                else if (usrv.Search(usr))
                {

                    usrv.UserMenu(usr); //Displays Customer side
                    return;
                }
                else
                {
                    WriteLine("Username or Pincode is incorrect.");
                    tries--;
                }
            }
            if (tries == 0)
            {
                //Disable Login
                WriteLine("Admin has disabled this Login.");
            }
        }
    }
}
