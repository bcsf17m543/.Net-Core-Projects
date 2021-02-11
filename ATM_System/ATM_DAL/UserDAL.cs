using ATM_BO;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
namespace ATM_DAL
{
    public class UserDAL:BaseDAL
    {
        public void SaveUser(UserBO bo)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString("dd/MM/yyyy");
            string text = $"{bo.Login},{bo.Pincode},{bo.Name},{bo.UsrAccNum},{bo.Starting_balance},{bo.Type},{bo.Status},{date}";
            Save(text, "CustomerData.csv");
        }
       public void UpdateUser(UserBO bo,string previous_date) //so that creation date remains 
        {                                                     //preserved while updating account info
            string text = $"{bo.Login},{bo.Pincode},{bo.Name},{bo.UsrAccNum},{bo.Starting_balance},{bo.Type},{bo.Status},{previous_date}";
            Save(text, "CustomerData.csv");
        }
        public void Make_Empty()
        {
            string filename = "CustomerData.csv";
            MakeEmpty(filename);
        }
        public List<DateTime> ReadCreationTimes()
        {
            List<String> stringList = Read("CustomerData.csv");
            string format = "dd/MM/yyyy";
            DateTime result;
            CultureInfo provider = CultureInfo.InvariantCulture;
            List<DateTime> dates = new List<DateTime>();
            foreach (string s in stringList)
            {
                string[] data = s.Split(",");
                result = DateTime.ParseExact(data[7],format, provider);
                dates.Add(result);
            }
            return dates;
        }
        public List<UserBO> ReadUser()
        {
            List<String> stringList = Read("CustomerData.csv");
            List<UserBO> usrList = new List<UserBO>();
            foreach (string s in stringList)
            {

                string[] data = s.Split(",");
                UserBO e = new UserBO();
                e.Login = data[0];
                e.Pincode = data[1];
                e.Name = data[2];
                e.UsrAccNum = System.Convert.ToInt32(data[3]);
                e.Starting_balance = System.Convert.ToInt32(data[4]);
                e.Type = data[5];
                e.Status = data[6];
                usrList.Add(e);
            }

            return usrList;

        }
       
    }
}
