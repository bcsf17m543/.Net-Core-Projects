using System;
using System.Collections.Generic;
using System.Text;
using ATM_BLL;
using ATM_BO;
using static System.Console;
using System.Threading;


namespace ATM_View
{
    public class AdminView
    {
        public void Admin_Menu()
        {
            bool progress = true;
            while (progress)
            {
                int opt;
                Console.Clear();
                WriteLine("Select an option.");
                WriteLine("1----Create New Account.");
                WriteLine("2----Delete Existing Account.");
                WriteLine("3----Update Account Information.");
                WriteLine("4----Search for Account.");
                WriteLine("5----View Reports");
                WriteLine("6----Exit");
                opt = System.Convert.ToInt32(ReadLine());
                switch (opt)
                {
                    case 1:
                        CreateNewAccount();
                        Thread.Sleep(3000); //So that you can see output of successful operation
                        break;
                    case 2:
                        DeleteAccount();
                        Thread.Sleep(3000);
                        break;
                    case 3:
                        UpdateAccountInfo();
                        Thread.Sleep(3000);
                        break;
                    case 4:
                        SearchAccount();
                        Thread.Sleep(3000);
                        break;
                    case 5:
                        ViewReports();
                        Thread.Sleep(9000);
                        break;
                    case 6:
                        progress = false;
                        break;
                }
            }
            
           
        }
        public void CreateNewAccount()
        {
            Console.Clear();
            WriteLine("Enter Login.");
            string log = ReadLine();
            WriteLine("Enter Pincode");
            string pin = ReadLine();
            WriteLine("Holder's Name");
            string nam = ReadLine();
            WriteLine("Type(Savings, Current)");
            string typ = ReadLine();
            WriteLine("Starting Balance");
            int bal = System.Convert.ToInt32(ReadLine());
            WriteLine("Status(active,disabled)");
            string stat = ReadLine();
            UserBLL bll = new UserBLL();
            UserBO obj = new UserBO { Login = log, Pincode = pin, Name = nam, UsrAccNum = 0, Starting_balance = bal, Type = typ, Status = stat };
            if (bll.CheckLength(pin)){
                UserView v = new UserView();
                string msg = bll.Save_User(obj);
                WriteLine(msg);
            }
            else
            {
                WriteLine("Account cannot be created Check pincode length (must b 5 characters)");
            }
        }
        public void DeleteAccount()
        {
            Console.Clear();
            WriteLine("Enter the Account number you wish to delete");
            int num = System.Convert.ToInt32(ReadLine());
            UserView v = new UserView();
            v.DeleteAccount(num);
        }
        public void UpdateAccountInfo()
        {
            WriteLine("Enter the Account Number:");
            int num = System.Convert.ToInt32(ReadLine());
            UserView v = new UserView();
            v.UpdateAccount(num);
        }
        public void SearchAccount()
        {
            UserView v = new UserView();
            v.SearchMenu();
        }
        public void ViewReports()
        {
            UserView v = new UserView();
            WriteLine("1.---Accounts by Amount\n2.---Accounts by Date");
            int num = System.Convert.ToInt32(ReadLine());
            if(num==1)
            {
                v.SearchByAmount();
            }
            else if(num==2)
            {
                v.SearchByDate();
            }
        }
        public void CreateAccount() // used by the developer only
        {
            WriteLine("Enter Name");
            string name = ReadLine();
            WriteLine("Enter Password 5 digit pincode");
            string code = ReadLine();

            AdminBO adm = new AdminBO { Name = name, Pincode = code };
            AdminBLL bll = new AdminBLL();
            bll.Save_Admin(adm);
        }
      
      
        public void ShowAdmin() //For testing purpose only
        {
            WriteLine("You are an admin");
        }
       
        public bool Search(AdminBO adm) //For testing purpose only
        {
            AdminBLL bll = new AdminBLL();
            return bll.Search_adm(adm);

        }
        public void Display()
        {
            AdminBLL bll = new AdminBLL();
            List<AdminBO> list = bll.Read_Admin();
            foreach (AdminBO e in list)
            {
                Console.WriteLine($"Name : {e.Name} Pincode: {e.Pincode}");
            }
        }
    }
}
