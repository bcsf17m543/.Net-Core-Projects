using Online_Grocery_Store.DatabaseControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Online_Grocery_Store.Models
{
    class AdminServices
    {
        public void AddProduct(Product p) //Add New Product------1 ---------------
        {
            ObservableCollection<Product> items = ProductDB.GetAllProducts();
            if (IsUnique(p.Id, items))
            {
                items.Add(p);
            }
            ProductDB.SaveAllProducts(items);
        }
        public void DeleteProduct(int itemId) //Delete Product------------2------------
        {
            ProductDB.DeleteProd(itemId);
        }
        public ObservableCollection<Product> ViewProduct()//View Product-------------3--------------
        {
            ObservableCollection<Product> items = ProductDB.GetAllProducts();
            return items;
        }
        public bool IsUnique(int itemId, ObservableCollection<Product> items)
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

    }
}
