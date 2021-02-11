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
    //For the record of all the transactions of all the users
    public class TransactionBLL
    {
        public void Save_Transaction(ReportBO bo)
        {
            ReportDAL dal = new ReportDAL();
            dal.SaveReport(bo);
        }
        public List<ReportBO> Read_Report()
        {
            ReportDAL dal = new ReportDAL();
            List<ReportBO> lst = dal.ReadReport();

            return lst;
        }
        public void DeleteAcc(int num)
        {
            List<ReportBO> lst = Read_Report();
            lst.RemoveAt(num);
            UserDAL dal = new UserDAL();
            dal.Make_Empty();
            for (int i = 0; i < lst.Count; i++)
            {
                Save_Transaction(lst[i]);
            }
        }
        public ReportBO SearchByObject(UserO usr)
        {
            List<ReportBO> list = Read_Report();
            for (int i = 0; i < list.Count; i++)
            {
                if (String.Equals(list[i].Name, usr.Login))
                {
                    ReportBO obj = new ReportBO(list[i]);
                    DeleteAcc(i);
                    return list[i];
                }
            }
            return new ReportBO();
        }
        public bool Is24Hours(UserO usr)
        {
            ReportBO obj = SearchByObject(usr);
            DateTime temp;
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime today = DateTime.UtcNow.Date;
            if (obj.IsEmpty())
            {
                return false ;
            }
            try
            {
                temp = DateTime.ParseExact(obj.Date, "d/MM/yyyy", provider);

            }
            catch (Exception ex)
            {
                temp = temp = DateTime.ParseExact(obj.Date, "dd/MM/yyyy", provider);
            }
            DateTime NoOfHours = temp.AddDays(1);
            int Amount = System.Convert.ToInt32(obj.Amount);
            if (Amount>20000 && today<NoOfHours)
            {
                return true;
            }
            return false;
        }
    }
}
