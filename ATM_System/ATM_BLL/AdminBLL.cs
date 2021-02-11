using ATM_BO;
using ATM_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM_BLL
{
    public class AdminBLL
    {
       
        public void Save_Admin(AdminBO bo)
        {
            UserBLL reuse = new UserBLL(); // I am reusing the Encryption function                    
            bo.Pincode = reuse.Encrypt(bo.Pincode); //thats' why I created this object
            AdminDAL dal = new AdminDAL();
            dal.SaveAdmin(bo);
        }
        public List<AdminBO> Read_Admin()
        {
            AdminDAL dal = new AdminDAL();
            List<AdminBO> lst = dal.ReadAdmin();
            UserBLL reuse = new UserBLL();
            foreach (AdminBO obj in lst)
            {
                obj.Pincode = reuse.Decrypt(obj.Pincode);
            }
            return lst;
        }
        public bool Search_adm(AdminBO adm)
        {
            List<AdminBO> list = Read_Admin();
            for (int i = 0; i < list.Count; i++)
            {


                if (String.Equals(list[i].Name, adm.Name) && String.Equals(list[i].Pincode, adm.Pincode))
                {
                    return true;
                }

            }
            return false;
        }
    }
}
