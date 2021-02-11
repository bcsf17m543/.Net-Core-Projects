using Microsoft.Data.SqlClient;
using Online_Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Online_Grocery_Store.DatabaseControl
{
    public class ProductDB
    {
        public static void UpdateWhole(Product p) //admin side update
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineGroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = $"Update Products Set Name='{p.Prodname}',Price='{p.Price}',Qty='{p.Qty}' where Id={p.Id}";
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateProduct(Product p) //customer side update
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineGroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = $"Update Products Set Qty='{p.Qty}' where Id='{p.Id}'";
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }
        public static Product GetProduct(int ide)
        {
            Product temp = new Product();
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineGroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlParameter parameter1 = new SqlParameter("ide", ide);

            string query = $"Select id,Name,Price,Qty from Products where id=@ide";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.Add(parameter1);

            SqlDataReader sqlDr = com.ExecuteReader();
            while (sqlDr.Read())
            {
                temp.Id = System.Convert.ToInt32(sqlDr[0]);
                temp.Prodname = sqlDr[1].ToString();
                temp.Price = System.Convert.ToInt32(sqlDr[2]);
                temp.Qty = System.Convert.ToInt32(sqlDr[3]);
            }
            con.Close();
            return temp;
        }
        public static bool IsUnique(int itemId, ObservableCollection<Product> items)
        {
            foreach (Product p in items)
            {
                if (itemId == p.Id)
                {
                    return false;
                }
            }
            return true;
        }
        public bool AllAreUnique(List<Product> items)
        {
            foreach (Product k in items)
            {
                foreach (Product p in items)
                {
                    if (k.Id == p.Id)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static void SaveAllProducts(ObservableCollection<Product> items) //Add Product
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineGroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query1 = "TRUNCATE TABLE  Products";
            SqlCommand com1 = new SqlCommand(query1, con);
            com1.ExecuteNonQuery();

            foreach (Product p in items)
            {
                string query = $"Insert into Products(Id,Name,Price,Qty) values ('{p.Id}','{p.Prodname}','{p.Price}','{p.Qty}')";
                SqlCommand com = new SqlCommand(query, con);
                int sqlDr = com.ExecuteNonQuery();
            }
            con.Close();

        }
        public static void DeleteProd(int itemid)
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineGroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = $"Delete from Products where Id='{itemid}'";
            SqlCommand com = new SqlCommand(query, con);
            int sqlDr = com.ExecuteNonQuery();
        }
        public static ObservableCollection<Product> GetAllProducts() //ViewProduct
        {
            ObservableCollection<Product> prods = new ObservableCollection<Product>();
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OnlineGroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select * from Products";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader sqlDr = com.ExecuteReader();
            while (sqlDr.Read())
            {
                Product temp = new Product
                {
                    Id = System.Convert.ToInt32(sqlDr[0])
                    ,
                    Prodname = sqlDr[1].ToString()
                    ,
                    Price = System.Convert.ToInt32(sqlDr[2])
                    ,
                    Qty = System.Convert.ToInt32(sqlDr[3])
                };
                prods.Add(temp);
            }
            con.Close();
            return prods;
        }
    }
}
