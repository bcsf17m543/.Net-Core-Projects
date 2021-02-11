using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_BO
{
    public class AdminBO
    {
        public string Name { get; set; }
        public string Pincode { get; set; }
        //if role is false then object is User
        //if role is true then object is Admin
        //When user runs the program and enters login credentials, first the app will
        //search the users in usersdata.csv then admindata.csv and then decides 
        //which menu will appear
      
    }
}
