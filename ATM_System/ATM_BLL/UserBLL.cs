using ATM_BO;
using ATM_DAL;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using static System.Console;
using System.Globalization;

namespace ATM_BLL
{
    public class UserBLL
    {
        public void Receipt_Deposit(UserBO obj, int amount) //When user Deposits cash
        {

            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString("dd/MM/yyyy");
            WriteLine($"Account # {obj.UsrAccNum}");
            WriteLine($"Date: {date}");
            WriteLine($"Deposited:{amount}");
            WriteLine($"Balance:{obj.Starting_balance}");
        }
        public void Transfer_Cash(UserO usr,int num,int amount) 
        {
            int idx = 0;
            List<UserBO> lst = Read_User();
            if(SearchAcc(lst, num, ref idx))
            {
                WriteLine($"You wish to transfer money to  the account of {lst[idx].Name}. If this information is correct please re-enter the account number:");
                int num2 = System.Convert.ToInt32(ReadLine());
                if(num==num2)
                {
                    UserBO obj = new UserBO(SearchByObject(usr));
                    UserBO from = new UserBO(obj);
                    if (from.Starting_balance >= amount)
                    {
                        UserBO towards = new UserBO(lst[idx]);
                        DeleteAcc(idx);
                        towards.Starting_balance = towards.Starting_balance + amount;
                        from.Starting_balance = from.Starting_balance - amount;
                        Save_User(towards);
                        Save_User(from);
                        WriteLine("transaction confirmed.");
                        DateTime dateTime = DateTime.UtcNow.Date;
                        string dat = dateTime.ToString("dd/MM/yyyy");
                        ReportBO repobj = new ReportBO { Type = "Cash Transferred", User_Id = from.UsrAccNum, Name = from.Name, Amount = amount.ToString(), Date = dat };
                        TransactionBLL tll = new TransactionBLL();
                        tll.Save_Transaction(repobj);
                        WriteLine("Do You wish to print a receipt(y/n)");
                        char ans2 = ReadKey().KeyChar;
                        if (ans2.Equals('y') || ans2.Equals('Y'))
                        {
                            Display_Transfer_Receipt(amount, obj);
                        }
                    }
                    else
                    {
                        Save_User(from);
                        WriteLine("You dont have enough money in your account");
                        return;
                    }


                }
            }
            else
            {
                WriteLine("This account does not exists.");
            }
        }
        public void Display_Transfer_Receipt(int amount,UserBO obj)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString("dd/MM/yyyy");
            WriteLine($"Account # {obj.UsrAccNum}");
            WriteLine($"Date: {date}");
            WriteLine($"Transferred:{amount}");
            WriteLine($"Balance:{obj.Starting_balance}");
        }
        public bool CheckDate(int amount) //A separate handling is done in TransactionBLL for 24 hours check
        {                                 //But if users enters amount >20000 at first try then this function is used
            if(amount>20000)               //Rather going to TransactionBLL and DAL layer
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool CheckBalance(UserBO usr,int amount)
        {
            if(usr.Starting_balance >=amount)
            { return true; 
            }
            else
            {
                return false;
            }
        }
       
        public UserBO SearchByObject(UserO usr) //For Retrieving the complete 
        {                                       //information of user from file
            List<UserBO> list = Read_User();
            for (int i = 0; i < list.Count; i++)
            {
                if (String.Equals(list[i].Login, usr.Login) && String.Equals(list[i].Pincode, usr.Pincode))
                {
                    UserBO obj = new UserBO(list[i]);
                    DeleteAcc(i);
                    return list[i];
                }
            }
            return new UserBO();
        }
        public List<UserBO> SearchByType(List<dynamic>objs) //For Dynamic Parametres of Searching
        {                                                   //This function is made so that Admin can input
            List<UserBO> mySearchList = new List<UserBO>(); //any number of user info parametres
            List<UserBO> lst = Read_User();
            for(int i=0;i<objs.Count;i++)
            {
                AddtoList(lst,objs[i],ref mySearchList);
            }
            return mySearchList;
        }
        public void AddtoList(List<UserBO> objs,dynamic obj,ref List<UserBO> myUsers) //Part os Dynamic Search
        {
            for(int i=0;i<objs.Count;i++)
            {
                if(objs[i].Name.Equals(obj)  && !myUsers.Contains(objs[i]))
                {
                    myUsers.Add(objs[i]);
                }
                if(objs[i].Login.Equals(obj) && !myUsers.Contains(objs[i]))
                {
                    myUsers.Add(objs[i]);
                }
                if(objs[i].Type.Equals(obj) && !myUsers.Contains(objs[i]))
                {
                    myUsers.Add(objs[i]);
                }
                if(objs[i].Status.Equals(obj) && !myUsers.Contains(objs[i]))
                {
                    myUsers.Add(objs[i]);
                }
                if(obj is int)
                {
                    if(objs[i].UsrAccNum == obj && !myUsers.Contains(objs[i]))
                    {
                        myUsers.Add(objs[i]);

                    }
                }
            }
        }
        public void UpdateAcc(int num,ref string msg) //Updation of account info in file By Admin Only
        {
            int idx = 0;
            List<UserBO> lst = Read_User();
            if (SearchAcc(lst, num, ref idx))
            {
                UserBO obj = new UserBO(lst[idx]);
                DeleteAcc(idx); 
                SetInfo(ref obj);
                Test_Save(obj);
                msg = "Account has been updated successfully";

            }
            else
            {
                msg = "Unsuccessful";
            }

        }
        public void SetPara(string log,string pin,string nam,string typ,string stat,ref UserBO obj) //Part of Dynamic Search
        {
            if(!string.IsNullOrEmpty(log) ||!string.IsNullOrWhiteSpace(log))
            {
                obj.Login = log;
            }
            if (!string.IsNullOrEmpty(pin) || !string.IsNullOrWhiteSpace(pin))
            {
                obj.Pincode = pin;
            }
            if (!string.IsNullOrEmpty(nam) || !string.IsNullOrWhiteSpace(nam))
            {
                obj.Name = nam;
            }
            if (!string.IsNullOrEmpty(stat) || !string.IsNullOrWhiteSpace(stat))
            {
                obj.Status = stat;
            }
            if (!string.IsNullOrEmpty(typ) || !string.IsNullOrWhiteSpace(typ))
            {
                obj.Type = typ;
            }
        }
        
        public void SetInfo(ref UserBO obj) //Part of Create Account
        {
            Console.Clear();
           int j= obj.UsrAccNum;
            obj.Display();
            int acc = obj.UsrAccNum;
            WriteLine("Please enter in the fields you wish to update (leave blank otherwise):");
            WriteLine("Enter Login.");
            string log = ReadLine();
            WriteLine("Enter Pincode");
            string pin = ReadLine();
            WriteLine("Holder's Name");
            string nam = ReadLine();
            WriteLine("Type(Savings, Current)");
            string typ = ReadLine();
            WriteLine("Status(active,inactive)");
            string stat = ReadLine();
            SetPara(log, pin, nam, typ, stat, ref obj);
            obj.UsrAccNum = acc;
        }
      
        public void DeleteAcc(int num) //Admin Deletes the account
        {
            List<UserBO> lst = Read_User();
            lst.RemoveAt(num);
            UserDAL dal = new UserDAL();
            dal.Make_Empty();
            for(int i=0;i<lst.Count;i++)
            {
                Test_Save(lst[i]);
            }
        }
        public bool CheckLength(string s)
        {
            if(s.Length!=5)
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        public string Save_User(UserBO bo) //Save Account to csv
        {
            string mesg;
            if(!Search_obj(bo))
            {
                List<UserBO> lst=Read_User();
                UserBO last = lst[lst.Count - 1];
                bo.UsrAccNum = last.UsrAccNum + 1;
                string cod = bo.Pincode;
                bo.Pincode = Encrypt(cod);
                UserDAL dal = new UserDAL();
                dal.SaveUser(bo);
                 mesg = "Account Successfully Created – the account number assigned is:" + bo.UsrAccNum;
            }
            else{
                 mesg = "Account cannot be created, try different Login or Pincode";

            }
            return mesg;
        }
      
        public void Test_Save(UserBO bo) //for initial testing by me only
        {
            bo.Pincode = Encrypt(bo.Pincode);
            UserDAL dal = new UserDAL();
            dal.SaveUser(bo);
        }
        public bool GetName(int num,ref string msg,ref int idx)
        {
            List<UserBO> lst = Read_User();
             msg = "This account number does not exists";
            if (SearchAcc(lst, num, ref idx))
            {
                msg = "you wish to delete the account held by" + lst[idx].Name;
                return true;
            }
            else
            {
                msg = "this account number does not exists";
                return false;
            }
        }
        public bool SearchAcc(List<UserBO> lst,int num,ref int idx)
        {
            for(int i=0;i<lst.Count;i++)
            {
                if(num == lst[i].UsrAccNum)
                {
                    idx = i;
                    return true;
                }
            }
            return false;
        }
          public bool Search_obj(UserO usr)
        {
            List<UserBO> list = Read_User();
            for (int i = 0; i < list.Count; i++)
            {


                if (String.Equals(list[i].Login, usr.Login) && String.Equals(list[i].Pincode, usr.Pincode))
                {
                    return true;
                }

            }
            return false;
        }
        public  string Decrypt(String code) //Decrypting Pincode after retrieving from file
        {
            string decStr=Encrypt(code);
            return decStr;
        }
        public int Contains(char[] arr, int size, char sub) //Part of encryption
        {
            for (int i = 0; i < size; i++)
            {
                if (arr[i].Equals(sub))
                {
                    return i;
                }

            }
            return 0;
        }
        public string Encrypt(string code) //Encryption of Pincode
        {                                   //Before Saving it to file
            char[] upperAlpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] lowerAlpha = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] Numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string encStr = null;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                char result = code[i];
                if (Char.IsUpper(code[i]))
                {
                    int idx = Contains(upperAlpha, 26, code[i]);
                    result = (char)((int)upperAlpha[25 - idx]);

                    str.Append(result);
                }
                if (Char.IsLower(code[i]))
                {
                    int idx = Contains(lowerAlpha, 26, code[i]);
                    result = (char)((int)lowerAlpha[25 - idx]);
                    str.Append(result);
                }
                if (Char.IsDigit(code[i]))
                {
                    int idx = Contains(Numbers, 10, code[i]);
                    result = (char)((int)Numbers[9 - idx]);
                    str.Append(result);
                }
                encStr = str.ToString();
            }
            return encStr;
        }
        public List<DateTime> Read_Creation_Time() //for testing purpose
        {
            UserDAL dal = new UserDAL();
            List<DateTime> dates = dal.ReadCreationTimes();
            return dates;
        }

        public List<UserBO> Read_User() //Reading daata from file
        {
            UserDAL dal = new UserDAL();
            List<UserBO> lst= dal.ReadUser();
            foreach(UserBO obj in lst)
            {
                obj.Pincode = Decrypt(obj.Pincode);
            }
            return lst;
        }
    }
}
