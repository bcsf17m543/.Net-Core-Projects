using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Blog_Application.Models
{
    public class BlogRepo
    {
        public static void AddBlog(Blog b,int id)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            try
            { 
                string query2 = $"Insert into Blog(Title,Content,usr_id,Date) values ('{b.Title}','{b.Content}','{id}','{b.Date}')";
                    SqlCommand com1 = new SqlCommand(query2, con);
                    com1.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }
        public static List<Blog> getMyBlogs(int myid)
        {
            
            List<Blog> myBlogs = new List<Blog>();
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter parameter1 = new SqlParameter("id", myid); //To avoid sql injection attack
            string query = "SELECT * FROM Blog WHERE usr_id=@id";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.Add(parameter1);
            SqlDataReader sqlDr = com.ExecuteReader();
            while (sqlDr.Read())
            {

                Blog temp = new Blog();
                temp.blog_Id = System.Convert.ToInt32(sqlDr[0].ToString());

                temp.Title = sqlDr[1].ToString();

                temp.Content = sqlDr[2].ToString();
                temp.Date = sqlDr[4].ToString();
               
                myBlogs.Add(temp);
            }
            con.Close();
            return myBlogs;
        }

        public static List<Blog> getAllBlogs(int id)
        {
            List<Blog> myBlogs = new List<Blog>();
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter parameter1 = new SqlParameter("id", id); //To avoid sql injection attack
            string query = "SELECT * FROM Blog INNER JOIN PublicUsr ON PublicUsr.Id = Blog.blog_Id WHERE PublicUsr.Id!=@id";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.Add(parameter1);
            SqlDataReader sqlDr = com.ExecuteReader();
            while (sqlDr.Read())
            {

                Blog temp = new Blog();
                temp.blog_Id = System.Convert.ToInt32(sqlDr[0].ToString());
                temp.Title = sqlDr[1].ToString();

                temp.Content = sqlDr[2].ToString();

                myBlogs.Add(temp);
            }
            con.Close();
            return myBlogs;
        }
        public static Blog getBlogById(int id)
        {
            // string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            Blog b = new Blog();
            SqlParameter parameter1 = new SqlParameter("myid", id); //To avoid sql injection attack
            string query1 = $"Select * from Blog where blog_Id=@myid";
            SqlCommand com = new SqlCommand(query1, con);
            com.Parameters.Add(parameter1);
            SqlDataReader sqlDr = com.ExecuteReader();
            if (sqlDr.Read())
            {
                b.blog_Id = System.Convert.ToInt32(sqlDr[0].ToString());
                b.Title = sqlDr[1].ToString();
                b.Content=sqlDr[2].ToString();
                b.Date=sqlDr[4].ToString();
            }
            con.Close();
            return b;
        }
        public static void RemoveBlog(int id)
        {
            //string constr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MyBlogApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            Blog b = new Blog();
            SqlParameter parameter1 = new SqlParameter("myid", id); //To avoid sql injection attack
            string query1 = $"Delete from Blog where blog_Id=@myid";
            SqlCommand com = new SqlCommand(query1, con);
            com.Parameters.Add(parameter1);
            int rec = com.ExecuteNonQuery();
            con.Close();
        }
    }
}
