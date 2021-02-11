using ATM_BLL;
using ATM_BO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using static System.Console;
using System.Linq.Expressions;
using System.Threading;
namespace ATM_View
{
    public class UserView
    {
        
        public void WithDrawCash(UserO usr,ref bool MaxAmount,ref DateTime tomorrow)
        {
            TransactionBLL tll = new TransactionBLL();
            DateTime today = DateTime.UtcNow.Date;
            if(today==tomorrow)
            {
                MaxAmount = false;
            }
            if(tll.Is24Hours(usr))
            {
                MaxAmount = false;
            }
            if(MaxAmount)
            {
                WriteLine("You cannot withdraw more than 20000 in one day.Please wait for 24 hours.");
                return;
            }
            Console.Clear();
            WriteLine("1---Fast Cash");
            WriteLine("2---Normal cash");
            int num = System.Convert.ToInt32(ReadLine());
            if(num==1)
            {
                FastCash(usr,ref MaxAmount);
            }
            else if(num ==2)
            {
                NormalCash(usr,ref MaxAmount);
            }
        }
        public void NormalCash(UserO usr,ref bool MaxAmount)
        {
            WriteLine("Enter the amount of money You want to withdraw");
            string amo = ReadLine();
            int amount;
            if (int.TryParse(amo, out amount))
            {
                amount = System.Convert.ToInt32(amo);
                UserBLL bll = new UserBLL();
                if (bll.CheckDate(amount))
                {
                    MaxAmount = true;
                    return;
                }
                WriteLine($"Are you sure you want to withdraw Rs.{amount}(Y/N)? ");
                char ans = ReadKey().KeyChar;
                if (ans.Equals('y') || ans.Equals('Y'))
                {
                    UserBO obj = new UserBO(bll.SearchByObject(usr));
                    UserBO cop = new UserBO(obj);
                    if (bll.CheckBalance(obj, amount))
                    {
                        obj.Starting_balance = obj.Starting_balance - amount;
                        bll.Test_Save(obj);
                        WriteLine("Ammount Withdrawn sucessfully");
                        DateTime dateTime = DateTime.UtcNow.Date;
                        string dat = dateTime.ToString("dd/MM/yyyy");
                        ReportBO repobj = new ReportBO { Type = "Cash Withdrawl", User_Id = obj.UsrAccNum, Name = obj.Name, Amount = amount.ToString(), Date = dat };
                        TransactionBLL tll = new TransactionBLL();
                        tll.Save_Transaction(repobj);
                        WriteLine("Do You wish to print a receipt(y/n)");
                        char ans2 = ReadKey().KeyChar;
                        if (ans2.Equals('y') || ans2.Equals('Y'))
                        {
                            Display_Recipt(amount, obj);
                        }
                       
                    }
                    else
                    {
                        bll.Test_Save(cop);
                        WriteLine("You dont have enough balance in your account");
                    }
                }
                else
                {
                    return;
                }

            }
            else
            {
                WriteLine("Please Enter a valid amount i.e, digits");
            }
        }
        public void Display_Recipt(int amount,UserBO obj)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString("dd/MM/yyyy");
            WriteLine($"Account # {obj.UsrAccNum}");
            WriteLine($"Date: {date}");
            WriteLine($"WithDrawn:{amount}");
            WriteLine($"Balance:{obj.Starting_balance}");
        }
        public void FastCash(UserO usr,ref bool MaxAmount)
        {
            Console.Clear();
            WriteLine("1----500");
            WriteLine("2----1000");
            WriteLine("3----2000");
            WriteLine("4----5000");
            WriteLine("5----10000");
            WriteLine("6----15000");
            WriteLine("7----20000");
            int opt = System.Convert.ToInt32(ReadLine());
            UserBLL bll = new UserBLL();
            int amount = Place_Balance(opt);
            if (bll.CheckDate(amount))
            {
                MaxAmount = true;
                return;
            }
            WriteLine($"Are you sure you want to withdraw Rs.{amount}(Y/N)? ");
            char ans = ReadKey().KeyChar;
            if (ans.Equals('y') ||ans.Equals('Y'))
            {
                UserBO obj = new UserBO(bll.SearchByObject(usr));
                UserBO cop = new UserBO(obj);
                if (bll.CheckBalance(obj, amount))
                {
                    obj.Starting_balance = obj.Starting_balance - amount;
                    bll.Test_Save(obj);
                    WriteLine("Ammount Withdrawn sucessfully");
                    DateTime dateTime = DateTime.UtcNow.Date;
                    string dat = dateTime.ToString("dd/MM/yyyy");
                    ReportBO repobj = new ReportBO{Type="Cash Withdrawl",User_Id=obj.UsrAccNum,Name=obj.Name,Amount=amount.ToString(),Date=dat};
                    TransactionBLL tll = new TransactionBLL();
                    tll.Save_Transaction(repobj);
                    WriteLine("Do You wish to print a receipt(y/n)");
                    char ans2 = ReadKey().KeyChar;
                    if (ans2.Equals('y') || ans2.Equals('Y'))
                    {
                        Display_Recipt(amount, obj);
                    }
                  
                }
                else
                {
                    bll.Test_Save(cop);
                    WriteLine("You dont have enough balance in your account");
                }
            }
            else
            {
                WriteLine("GoodLuck");
            }
        }
        public int Place_Balance(int opt)
        {
            switch(opt)
            {
                case 1:
                    return 500;
                case 2:
                    return 1000;
                case 3:
                    return 2000;
                case 4:
                    return 5000;
                case 5:
                    return 10000;
                case 6:
                    return 15000;
                case 7:
                    return 20000;
                default:
                    return 100;
            }
        }
        public void SearchMenu()
        {
            List<dynamic> parametres = new List<dynamic>();
            WriteLine("User Id");
            string log = ReadLine();
            WriteLine("Account ID");//account number 
            string num = ReadLine();
            int accNum = 0;
            if(int.TryParse(num, out accNum))
            {
                parametres.Add(accNum);
            }
            WriteLine("Holder's Name");
            string nam = ReadLine();
            WriteLine("Type(current,savings)");
            string typ = ReadLine();
            WriteLine("Status(active,disabled)");
            string stat = ReadLine();
            parametres.Add(log);
            parametres.Add(nam);
            parametres.Add(typ);
            parametres.Add(stat);
            UserBLL bll = new UserBLL();
            List<UserBO> srchLst = bll.SearchByType(parametres);
            ShowSearchList(srchLst);
        }
        public void UpdateAccount(int num)
        {
            string msg = "Account does not exists";
            UserBLL bll = new UserBLL();
            bll.UpdateAcc(num,ref msg);
            WriteLine(msg);
        }
        public void DeleteAccount(int num)
        {  //Deletes the account from list and saves that list into file
            UserBLL bll = new UserBLL();
            string msg = "";
            int idx = 0;
            bll.GetName(num, ref msg,ref idx);
            if(bll.GetName(num, ref msg,ref idx))
            {
                WriteLine(msg);
                WriteLine("; If this information is correct please re - enter the account number: ");
                int num2 = System.Convert.ToInt32(ReadLine());
                if (num == num2)
                {
                    bll.DeleteAcc(idx);
                    msg = "Account deleted successfully.";
                    WriteLine(msg);
                }
            }
            else
            {
                 msg="Unsuccessful";
                WriteLine(msg);
            }
        }
        public void CreateAccount() //for initial testing I made this
        {
            WriteLine("Enter Name");
            string name = ReadLine();
            WriteLine("Enter Password 5 digit pincode");
            string code = ReadLine();
           
                UserBO obj = new UserBO { Login = name, Pincode = code };
                UserBLL bll = new UserBLL();
                bll.Save_User(obj);
          
               
        }
       
        public void UserMenu(UserO usr) //UserView of ATM
        {
            bool MaxAmount = false;
            DateTime tomorrow = DateTime.UtcNow.Date.AddDays(1);
            bool progress = true;
            while (progress)
            {
                int opt;
                Console.Clear();
                WriteLine("Select an option.");
                WriteLine("1----Withdraw Cash");
                WriteLine("2----Cash Transfer");
                WriteLine("3----Deposit Cash");
                WriteLine("4----Display Balance");
                WriteLine("5----Exit");
                opt = System.Convert.ToInt32(ReadLine());
                switch (opt)
                {
                    case 1:
                        WithDrawCash(usr, ref MaxAmount,ref tomorrow);
                        Thread.Sleep(3000);
                        break;
                    case 2:
                        CashTransfer(usr);
                        Thread.Sleep(4000);
                        break;
                    case 3:
                        DepositCash(usr);
                        Thread.Sleep(5000);
                        break;
                    case 4:
                        Dispaly_Balance(usr);
                        Thread.Sleep(5000);
                        break;
                    case 5:
                        progress = false;
                        break;
                }
            }
        }
        public void Dispaly_Balance(UserO usr) //Dispalys logged in users Balance
        {
            UserBLL bll = new UserBLL();
            UserBO obj = new UserBO(bll.SearchByObject(usr));
            UserBO RetToFile = new UserBO(obj);
            DateTime dateTime = DateTime.UtcNow.Date;
            string dat = dateTime.ToString("dd/MM/yyyy");
            bll.Save_User(RetToFile);
            WriteLine($"Account # {RetToFile.UsrAccNum}\nDate:{dat}\nBalance: {RetToFile.Starting_balance}");

        }
        public void DepositCash(UserO usr)
        {
            WriteLine("Enter the amount to deposit:");
            string amo = ReadLine();
            int amount;
            if(int.TryParse(amo,out amount))
            {
                amount = System.Convert.ToInt32(amo);
                UserBLL bll = new UserBLL();
                UserBO obj = new UserBO(bll.SearchByObject(usr));
                UserBO Deposit = new UserBO(obj);
                Deposit.Starting_balance = Deposit.Starting_balance + amount;
                bll.Save_User(Deposit);
                WriteLine("Deposit successful.");
                DateTime dateTime = DateTime.UtcNow.Date;
                string dat = dateTime.ToString("dd/MM/yyyy");
                ReportBO repobj = new ReportBO { Type = "Cash Deposit", User_Id = obj.UsrAccNum, Name = obj.Name, Amount = amount.ToString(), Date = dat };
                TransactionBLL tll = new TransactionBLL();
                tll.Save_Transaction(repobj);
                WriteLine("Do you wish to print a reciept?(y/n)");
                char ans2 = ReadKey().KeyChar;
                if (ans2.Equals('y') || ans2.Equals('Y'))
                {
                    bll.Receipt_Deposit(obj, amount);
                }
            }
            else
            {
                WriteLine("Amount enetered was not in a correct format");
            }
        }
        public  bool isMultipleof5(int n)
        {
            while (n > 0)
            {
                n = n - 5;

            }
            if (n == 0)
            {
                return true;

            }
            return false;
        }
        public void CashTransfer(UserO usr)
        {
            WriteLine("Enter the amount in multiples of 5:");
            string amou = ReadLine();
            int amount;
            if(int.TryParse(amou,out amount))
            {
                amount = System.Convert.ToInt32(amou);
                if(isMultipleof5(amount))
                {
                    UserBLL bll = new UserBLL();
                    if (!bll.CheckDate(amount))
                    {
                        WriteLine("Enter the account number to which you want to transfer.");
                        int num = System.Convert.ToInt32(ReadLine());
                        bll.Transfer_Cash(usr, num, amount);
                    }
                    else
                    {
                        WriteLine("You are exceeding maximum amount transfer limit.");
                    }
                }
                else
                {
                    WriteLine("The amount entered is not a multiple if 5");
                }

              
            }
        }
        public bool Search(UserO usr)
        {
            UserBLL bll = new UserBLL();
            return bll.Search_obj(usr);
        }
        public void Test(UserBO usr)
        {
            UserBLL bll = new UserBLL();
            bll.Test_Save(usr);

        }
        public void ShowSearchList(List<UserBO> results)
        {
            if(results.Count==0)
            {
                WriteLine("No account matches details that you entered");
                return;
            }
            string head = String.Format("{0,-15} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}","Account ID","User ID","Holders Name","Type","Balance","Status");
            WriteLine(head);
            foreach (UserBO e in results)
            {
                WriteLine("{0,-15} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}",e.UsrAccNum,e.Login,e.Name,e.Type,e.Starting_balance,e.Status);
            }
        }
        public void DisplayDateRange(DateTime min,DateTime max)
        {
            UserBLL bll = new UserBLL();
            TransactionBLL tll = new TransactionBLL();
            List<ReportBO> lst = tll.Read_Report();
            string head = String.Format("{0,-15} {1,-10} {2,-10} {3,-10} {4,-10}", "Transaction Type", "User ID", "Holders Name", "Amount", "Date");
            WriteLine(head);
            for (int i=0;i<lst.Count;i++)
            {
                DateTime temp;
                CultureInfo provider = CultureInfo.InvariantCulture;
                try
                {
                    temp = DateTime.ParseExact(lst[i].Date, "d/MM/yyyy", provider);

                }
                catch(Exception ex)
                {
                    temp = temp = DateTime.ParseExact(lst[i].Date, "dd/MM/yyyy", provider);
                }
                if (temp>=min.Date && temp<=max.Date)
                {
                    WriteLine("{0,-15} {1,-10} {2,-10} {3,-10} {4,-10}", lst[i].Type,lst[i].User_Id,lst[i].Name,lst[i].Amount,lst[i].Date);
                }
            }
        }

        public void SearchByDate()
        {
            WriteLine("Enter the starting date: (dd/MM/YYYY)");
            string str = ReadLine();
            DateTime min, max;
            CultureInfo provider = CultureInfo.InvariantCulture;
            try 
            {
                min = DateTime.ParseExact(str,"dd/MM/yyyy", provider);
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
                return;
            }
            WriteLine("Enter ending date: (dd/MM/YYYY)");
             string gstr = ReadLine();
            try 
            {
                 max = DateTime.ParseExact(gstr,"dd/MM/yyyy", provider);
            }
            catch(Exception exp)
            {
                WriteLine(exp.Message);
                return;
            }
            DisplayDateRange(min, max);

        }
        public void SearchByAmount()
        {
            WriteLine("Enter minimum range:");
            string str = ReadLine();
            int min, max = 0;
            if (int.TryParse(str,out min))
            {
                 min = System.Convert.ToInt32(str);
            }
            else
            {
                WriteLine("Input is not in a correct format");
                return;
            }
            WriteLine("Enter maximum range:");
            str = ReadLine();
            if (int.TryParse(str, out max))
            {
                max = System.Convert.ToInt32(str);
            }
            else
            {
                WriteLine("Input is not in a correct format");
                return;
            }
            DisplayRange(min,max);
        }
        public void DisplayRange(int min,int max)
        {
            UserBLL bll = new UserBLL();
            List<UserBO> lst = bll.Read_User();
            string head = String.Format("{0,-10} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}", "Account ID", "User ID", "Holders Name", "Type", "Balance", "Status");
            WriteLine(head);
            for (int i=0;i<lst.Count;i++)
            {
                if(lst[i].Starting_balance>=min &&lst[i].Starting_balance<=max)
                {
                    WriteLine("{0,-10} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}", lst[i].UsrAccNum, lst[i].Login, lst[i].Name, lst[i].Type, lst[i].Starting_balance, lst[i].Status);
                }
            }
        }
        public void Display()
        {
            UserBLL bll = new UserBLL();
            List<UserBO> list = bll.Read_User();
            foreach (UserBO e in list)
            {
                Console.WriteLine($"Name : {e.Login} Pincode: {e.Pincode}");
            }
        }
    }
}
