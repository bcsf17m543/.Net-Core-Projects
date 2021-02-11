using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Blog_Application.Models
{
    public class AdminRepo
    {
        public static Admin Login(string code,ref bool isLogin)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter parameter1 = new SqlParameter("adm", code); //To avoid sql injection attack
            string query1 = $"Select * from Admin where adm_Id=@adm";
            SqlCommand com = new SqlCommand(query1, con);
            com.Parameters.Add(parameter1);
            SqlDataReader sqlDr = com.ExecuteReader();
            Admin temp = new Admin();
            while (sqlDr.Read())
            {


                temp.Code = sqlDr[0].ToString();

                isLogin = true;

            }
            con.Close();
            return temp;
        }
    }
}
