using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ATM_BO
{
    //Actually it is Transaction class but it is being used
    //At Admin side for viewing the reports so I initially named it as ReportBO
    public class ReportBO
    {
        public string Type { get; set; }
        public int User_Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public ReportBO(ReportBO ob)
        {
            Type = ob.Type;
            User_Id = ob.User_Id;
            Name = ob.Name;
            Amount = ob.Amount;
            Date = ob.Date;

        }
        public ReportBO()
        {
            Type = "";
            User_Id = 0;
            Name = "";
            Amount = "";
            Date = "";

        }
        public bool IsEmpty()
        {
            if(Type=="")
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
