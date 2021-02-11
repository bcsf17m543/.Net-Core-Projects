using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Blog_Application.Models
{
    public class ProfileRepo
    {
        public static Profile GetProfile(int usr_Id)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = $"Select * from Profile where usr_Id='{usr_Id}'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader sqlDr = com.ExecuteReader();
            Profile temp = new Profile();
            temp.Usrinfo = PublicUserRepo.getUserbyId(usr_Id);
            while (sqlDr.Read())
            {
                temp.Emailaddress = sqlDr[1].ToString();
                temp.ImagePath = sqlDr[2].ToString();
            }
            con.Close();
            return temp;
        }
       
        public static void UpdateProfile(int usrid,Profile pro)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            try
            {
                //Profile Table Updation
                string query1 = $"Insert into Profile(email,image,usr_Id) values ('{pro.Emailaddress}','{pro.ImagePath}','{usrid}')";
                SqlCommand com = new SqlCommand(query1, con);
                com.ExecuteNonQuery();
                //PublicUsr Table Updation
                string query2 = $"Insert into PublicUsr(Name,Password,Phone) values ('{pro.Usrinfo.Name}','{pro.Usrinfo.Password}','{pro.Usrinfo.Phone}') where usr_Id='{usrid}'";
                SqlCommand com2 = new SqlCommand(query1, con);
                com2.ExecuteNonQuery();


            }
            finally
            {
                con.Close();
            }
        }
        public static void DeleteProfile(int usrid)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter parameter1 = new SqlParameter("myid", usrid); //To avoid sql injection attack
            string query1 = $"Delete from Profile where usr_Id=@myid";
            SqlCommand com = new SqlCommand(query1, con);
            com.Parameters.Add(parameter1);
            int rec = com.ExecuteNonQuery();
            con.Close();
        }
        public static string GetImagePath(int usr_Id)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = $"Select * from Profile where usr_Id='{usr_Id}'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader sqlDr = com.ExecuteReader();
            string temp="";
            while (sqlDr.Read())
            {
                temp = sqlDr[2].ToString();
            }
            con.Close();
            return temp;
        }
    }
}
