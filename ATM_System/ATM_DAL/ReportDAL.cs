using ATM_BO;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
namespace ATM_DAL
{
    public class ReportDAL:BaseDAL
    {
        public void SaveReport(ReportBO bo)
        {
           
            string text = $"{bo.Type},{bo.User_Id},{bo.Name},{bo.Amount},{bo.Date}";
            Save(text, "ReportsData.csv");
        }
        public List<ReportBO> ReadReport()
        {
            List<String> stringList = Read("ReportsData.csv");
            List<ReportBO> repList = new List<ReportBO>();
            foreach (string s in stringList)
            {
                string[] data = s.Split(",");
                ReportBO e = new ReportBO();
                e.Type = data[0];
                e.User_Id = System.Convert.ToInt32(data[1]);
                e.Name = data[2];
                e.Amount = data[3];
                e.Date = data[4];
                repList.Add(e);
            }

            return repList;

        }
    }
}
