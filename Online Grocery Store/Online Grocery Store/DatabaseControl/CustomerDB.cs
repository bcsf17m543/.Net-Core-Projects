using Microsoft.Data.SqlClient;
using Online_Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Online_Grocery_Store.DatabaseControl
{
    class CustomerDB
    {
        public static void SignUp(Customer c,ref bool IsSign)
        {


            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineGroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constr);
            SqlConnection con2 = new SqlConnection(constr);
            con.Open();
            try
            {
                SqlParameter parameter1 = new SqlParameter("Nam", c.Name); //T avoid sql injection attack
                SqlParameter parameter2 = new SqlParameter("Pass", c.Password);
                string query1 = $"Select Name,Password,Phone from Customer where Name=@Nam";
                SqlCommand com = new SqlCommand(query1, con);
                com.Parameters.Add(parameter1);
                com.Parameters.Add(parameter2);
                SqlDataReader sqlDr = com.ExecuteReader();
                if (!sqlDr.Read())
                {
                    con2.Open();
                    IsSign = true;
                    string query2 = $"Insert into Customer(Name,Password,Phone) values ('{c.Name}','{c.Password}','{c.Phone}')";
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
            public static Customer Login(string name,string pass)
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineGroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter parameter1 = new SqlParameter("Nam", name); //Tavoid sql injection attack
            SqlParameter parameter2 = new SqlParameter("Pass", pass);
            string query1 = $"Select Name,Password,Phone from Customer where Name=@Nam and Password =@Pass";
            SqlCommand com = new SqlCommand(query1, con);
            com.Parameters.Add(parameter1);
            com.Parameters.Add(parameter2);
            SqlDataReader sqlDr = com.ExecuteReader();
            Customer temp = new Customer();
            while (sqlDr.Read())
            {


                temp.Name = sqlDr[0].ToString();

                temp.Password = sqlDr[1].ToString();               
                temp.Phone = System.Convert.ToInt64(sqlDr[2].ToString());

               

            }
            con.Close();
            return temp;
        }
        public static List<Customer> GetAllCustomers() //SignUp Verification
        {
            List<Customer> custms = new List<Customer>();
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineGroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select * from Customer";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader sqlDr = com.ExecuteReader();
            long num = 0;
            while (sqlDr.Read())
            {

                Customer temp = new Customer();

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




                custms.Add(temp);
            }
            con.Close();
            return custms;
        }
    }
}

