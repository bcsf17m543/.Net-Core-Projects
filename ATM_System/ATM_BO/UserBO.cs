using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace ATM_BO
{
    //A generic UserType was made because it is 
    //impossible to create a users Bank account at Login time,So
    //I made this class and actual customer class inherits from it i.e, UserBO
    public class UserBO: UserO
    {
      
        public string Name { get; set; }
        public int UsrAccNum { get; set; }
        public int Starting_balance { get; set; }
        private string status;
        public string Status {
            set
            {
                if (value.ToLower().Equals("active") || value.ToLower().Equals("disabled"))
                {
                    status = value;
                }
            }
            get { return status; }
        }
        private string type;
        public string Type
        {
            set
            {
                if (value.ToLower().Equals("savings") || value.ToLower().Equals("current"))
                {
                    type = value;
                }
            }
            get { return type; }
        }
        public UserBO()
        {
            Login = "";
            Pincode = "";
            Name = "";
            Starting_balance = 0;
            Type = "";
            Status = "";

        }
        public UserBO(string a,string b,string c,int am,string d,string e)
        {
            Login = a;
            Pincode = b;
            Name = c;
            Starting_balance = 0;
            Status = d;
            Type = e;

        }
        public UserBO(UserBO ob)
        {
            Login = ob.Login;
            Pincode = ob.Pincode;
            Name = ob.Name;
            UsrAccNum = ob.UsrAccNum;
            Starting_balance = ob.Starting_balance;
            Status = ob.Status;
            Type = ob.Type;

        }
        public void Display()
        {
            WriteLine($"Account #{UsrAccNum}\nType: {Type}\nHolder: {Name}\nBalance: {Starting_balance}\nStatus: {Status}");
        }
        public bool IsActive()
        {
            if(Status.ToLower().Equals("active"))
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
