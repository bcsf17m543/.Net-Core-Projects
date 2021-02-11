using System;
using System.Collections.Generic;
using System.Text;
using ATM_BO;
using System.IO;
namespace ATM_DAL
{
    public class AdminDAL:BaseDAL
    {
        public void SaveAdmin(AdminBO bo)
        {
            string text = $"{bo.Name},{bo.Pincode}";
            Save(text, "AdminData.csv");
        }
        public List<AdminBO> ReadAdmin()
        {
            List<String> stringList = Read("AdminData.csv");
            List<AdminBO> admList = new List<AdminBO>();
            foreach (string s in stringList)
            {

                string[] data = s.Split(",");
                AdminBO e = new AdminBO();
                e.Name = data[0];
                e.Pincode = data[1];
                admList.Add(e);
            }

            return admList;

        }
    }
}
