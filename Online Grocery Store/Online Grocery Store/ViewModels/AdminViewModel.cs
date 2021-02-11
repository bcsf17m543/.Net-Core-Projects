using Online_Grocery_Store.Commands;
using Online_Grocery_Store.DatabaseControl;
using Online_Grocery_Store.Models;
using Online_Grocery_Store.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Online_Grocery_Store.ViewModels
{
    class AdminViewModel : BaseViewModel
    {



        AdminServices adminService;
        public Action CloseAction { get; set; }
        public DelegateCommand2 FinishCommand2 { get; set; }
        public DelegateCommand cmd1 { get; set; }
        public DelegateCommand cmd2 { get; set; }
        public DelegateCommand cmd3 { get; set; }

      
        public AdminViewModel()
        {
            adminService = new AdminServices();
            cmd1 = new DelegateCommand(AddProduct, canAdd);
            cmd2 = new DelegateCommand(DeleteProduct, canDelete);
            cmd3 = new DelegateCommand(ViewProd,canClose);
            FinishCommand2 = new DelegateCommand2(Finish, canClose);
        }
        public void Finish(object o)
        {
            CloseAction();
        }
        public bool canDelete(object o)
        {
            try
            {
                TextBox t = o as TextBox;
                int Id;
                if (!string.IsNullOrEmpty(t.Text) && int.TryParse(t.Text, out Id))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(NullReferenceException ex)
            {
                return false;
            }
        }
        public void DeleteProduct(object o)
        {
            string id=(o as TextBox).Text;
            int pid = System.Convert.ToInt32(id);
            if(pid<0 || pid==0)
            {
                MessageBox.Show("Please Enter a valid Id");
            }
            else
            {
                ProductDB.DeleteProd(pid);
                MessageBox.Show("Product Deleted Sucessfully.");

            }
        }
        public void ViewProd(object o)
        {
            ObservableCollection<Product> items=adminService.ViewProduct();
            ProductView prods = new ProductView(items);
            prods.Show();
        }
       
       

        public bool canClose(object o)
        {
            return true;
        }
        public bool canAdd(object o)
        {
            try
            {

                var objects = o as List<object>;
                TextBox id = objects[0] as TextBox;
                TextBox name = objects[1] as TextBox;
                TextBox price = objects[2] as TextBox;
                TextBox qty = objects[3] as TextBox;
                if (string.IsNullOrEmpty(id.Text) || string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(price.Text) ||string.IsNullOrEmpty(qty.Text) )
                {
                    return false;
                }
                else
                {
                    return true;
                }
               
            }
            catch (NullReferenceException ex)
            {
                return false;
            }
        }
        public bool ValidateProduct(List<object>objs)
        {
            bool ans = true;
            string name = (objs[1] as TextBox).Text;
            string ide = (objs[0] as TextBox).Text;
            string pricee = (objs[2] as TextBox).Text;
            string qtyy = (objs[3] as TextBox).Text;
            int num, pri, quant;
            if(name.Length>20)
            {
                ans = false;
                return ans;
            }
            if(int.TryParse(ide,out num))
            {
                int pid = System.Convert.ToInt32(ide);
                if(pid<0 ||pid==0 || ide.Length>10)
                {
                    ans = false;
                    return ans;
                }
            }
            else
            {
                ans = false;
                return ans;
            }
            if (int.TryParse(pricee, out pri))
            {
                int ppr = System.Convert.ToInt32(pricee);
                if (ppr < 0 || pricee.Length>10)
                {
                    ans = false;
                    return ans;
                }
            }
            else
            {
                ans = false;
                return ans;
            }
            if (int.TryParse(qtyy, out quant))
            {
                int pqt = System.Convert.ToInt32(quant);
                if (pqt < 0 ||qtyy.Length>10)
                {
                    ans = false;
                    return ans;
                }
            }
            else
            {
                ans = false;
                return ans;
            }
            return ans;
        }
        public void AddProduct(object o)
        {
            var objects = o as List<object>;
            if (!ValidateProduct(objects))
            {
                TextBlock teta = (objects[4] as TextBlock);
                teta.Text = "Please Enter valid Inputs,\nCheck if you have entered\n invalid Id or negative\n numbers";
            }
            else if (ValidateProduct(objects))
            {
                TextBlock teta = (objects[4] as TextBlock);
                teta.Text = "Correct Input";
                Product newProd = new Product
                {
                    Id = System.Convert.ToInt32((objects[0] as TextBox).Text),
                    Prodname = (objects[1] as TextBox).Text,
                    Price = System.Convert.ToInt32((objects[2] as TextBox).Text),
                    Qty = System.Convert.ToInt32((objects[3] as TextBox).Text)
                };
                ObservableCollection<Product> prods = ProductDB.GetAllProducts();
                if(ProductDB.IsUnique(newProd.Id,prods))
                {
                    prods.Add(newProd);
                    ProductDB.SaveAllProducts(prods);
                    MessageBox.Show("Product Added sucessfully");

                }
                else
                {
                    ProductDB.UpdateWhole(newProd);
                    MessageBox.Show("Id exists Already");
                }
            }


        }
        
    }
}
