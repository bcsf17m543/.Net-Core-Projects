using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace My_Blog_Application.Models
{
    public class PublicUserRepo
    {
        public static void SignUp(PublicUser c, ref bool IsSign)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            SqlConnection con2 = new SqlConnection(constr);
            con.Open();
            try
            {
                SqlParameter parameter1 = new SqlParameter("Nam", c.Name); //T0 avoid sql injection attack
                SqlParameter parameter2 = new SqlParameter("Pass", c.Password);
                string query1 = $"Select Name,Password,Phone from PublicUsr where Name=@Nam";
                SqlCommand com = new SqlCommand(query1, con);
                com.Parameters.Add(parameter1);
                com.Parameters.Add(parameter2);
                SqlDataReader sqlDr = com.ExecuteReader();
                if (!sqlDr.Read())
                {
                    con2.Open();
                    IsSign = true;
                    string query2 = $"Insert into PublicUsr(Name,Password,Phone) values ('{c.Name}','{c.Password}','{c.Phone}')";
                    SqlCommand com1 = new SqlCommand(query2, con2);
                    com1.ExecuteNonQuery();
                    con2.Close();
                }

            }
            finally
            {
                con.Close();
            }
        }
        public static PublicUser Login(string name, string pass,ref bool isLogin)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter parameter1 = new SqlParameter("Nam", name); //To avoid sql injection attack
            SqlParameter parameter2 = new SqlParameter("Pass", pass);
            string query1 = $"Select Name,Password,Phone from PublicUsr where Name=@Nam and Password =@Pass";
            SqlCommand com = new SqlCommand(query1, con);
            com.Parameters.Add(parameter1);
            com.Parameters.Add(parameter2);
            SqlDataReader sqlDr = com.ExecuteReader();
            PublicUser temp = new PublicUser();
            while (sqlDr.Read())
            {


                temp.Name = sqlDr[0].ToString();

                temp.Password = sqlDr[1].ToString();
                temp.Phone = System.Convert.ToInt64(sqlDr[2].ToString());

                isLogin = true;

            }
            con.Close();
            return temp;
        }
        public static int GetId(string name)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter parameter1 = new SqlParameter("Nam", name); //To avoid sql injection attack
            string query1 = $"Select Id from PublicUsr where Name=@Nam";
            SqlCommand com = new SqlCommand(query1, con);
            com.Parameters.Add(parameter1);
            SqlDataReader sqlDr = com.ExecuteReader();
            int myId = 0;
            if (sqlDr.Read())
            {
                myId = System.Convert.ToInt32(sqlDr[0].ToString());
            }
            return myId;
        }
        public static List<PublicUser> GetAllUsers() //SignUp Verification
        {
            List<PublicUser> usrs = new List<PublicUser>();
           // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select * from PublicUsr";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader sqlDr = com.ExecuteReader();
            long num = 0;
            while (sqlDr.Read())
            {

                PublicUser temp = new PublicUser();
                temp.id = System.Convert.ToInt32(sqlDr[0].ToString());
                temp.Name = sqlDr[1].ToString();

                temp.Password = sqlDr[2].ToString();
                if (long.TryParse(sqlDr[3].ToString(), out num))
                {
                    temp.Phone = System.Convert.ToInt64(sqlDr[3].ToString());

                }
                else
                {
                    temp.Phone = Convert.ToInt64(sqlDr[3].ToString());
                }




                usrs.Add(temp);
            }
            con.Close();
            return usrs;
        }
        public static List<Stream> getUserandPosts()
        {
            List<Stream> allUsersandPosts = new List<Stream>();
            List<PublicUser> allUsers = GetAllUsers();
           for(int i=0;i<allUsers.Count;i++)
            {
                Stream temp = new Stream();
                temp.oneUser =new PublicUser { Name=allUsers[i].Name,Password=allUsers[i].Password,Phone=allUsers[i].Phone};
                int usrId = GetId(allUsers[i].Name);
                List<Blog> usrBlogs = BlogRepo.getMyBlogs(usrId);
                temp.AllBlogs = usrBlogs;
                temp.imgPath = ProfileRepo.GetImagePath(usrId);
                allUsersandPosts.Add(temp);
                
                
            }
            return allUsersandPosts;


        }
        public static PublicUser getUserbyId(int id)
        {
           // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = $"Select * from PublicUsr where Id='{id}'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader sqlDr = com.ExecuteReader();
            long num = 0;
            PublicUser temp = new PublicUser();
            while (sqlDr.Read())
            {

                temp.id = System.Convert.ToInt32(sqlDr[0].ToString());
                temp.Name = sqlDr[1].ToString();

                temp.Password = sqlDr[2].ToString();
                if (long.TryParse(sqlDr[3].ToString(), out num))
                {
                    temp.Phone = System.Convert.ToInt64(sqlDr[3].ToString());

                }
                else
                {
                    temp.Phone = Convert.ToInt64(sqlDr[3].ToString());
                }

            }
            con.Close();
            return temp;
        }
        public static void RemoveById(int id)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter parameter1 = new SqlParameter("myid", id); //To avoid sql injection attack
            string query1 = $"Delete from PublicUsr where Id=@myid";
            SqlCommand com = new SqlCommand(query1, con);
            com.Parameters.Add(parameter1);
            int rec = com.ExecuteNonQuery();
        }
    }

}
