using Online_Grocery_Store.DatabaseControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Online_Grocery_Store.Models
{
    class CustomerServices
    {
        public ObservableCollection<Product> prods;
        public CustomerServices()
        {
            prods = new ObservableCollection<Product>();
        }
        public int countTotal()
        {
            int bill = 0;
            foreach(Product p in prods)
            {
                bill +=p.Price;
            }
            return bill;
        }
        public bool IfExists(Customer c,List<Customer> objs)
        {
            foreach(Customer cus in objs)
            {
                if(!cus.Name.Equals(c.Name) && !cus.Password.Equals(c.Password) && cus.Phone!=c.Phone)
                {
                    return true;
                }
               
            }
            return false;
        }
        public bool SignUpCust(string name,string pass,long phone,ref bool IsSign)
        {
            List<Customer> cstms1 = CustomerDB.GetAllCustomers();
            Customer c = new Customer { Name = name, Password = pass, Phone = phone };
           CustomerDB.SignUp(c,ref IsSign);
            return IfExists(c, cstms1);

        }
        public Customer LoginCust(string name,string pass)
        {
            Customer c=CustomerDB.Login(name, pass);
            return c;
        }
        public bool AddItem(int Id, int qtty)
        {
            Product p = ProductDB.GetProduct(Id);
            if (p != null && p.Qty >= qtty)
            {
                Product up = new Product(p);
               // p.Qty = qtty;
                up.Qty = up.Qty - qtty;
                p.Qty = qtty;
                prods.Add(p);
                ProductDB.UpdateProduct(up);
                return true;

            }
            return false;
        }

    }
}
