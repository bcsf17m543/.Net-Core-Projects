using ATM_View;
using System;
using static System.Console;
namespace ATM_System
{
    class Program
    {

        static void Main(string[] args)
        {
            GenericView view = new GenericView();
            try             //You can view Customer.csv and Admin.csv for logins but also
            {               //For Admin            // For User
              view.Login(); // Login: Samia        Login: Meeba
            }               // Password: abc54     Password:09876
            catch (Exception ex) //Please Wait for 3 seconds after checking each functionality
            {                   //Terminal will automatically go to the Menu,After that,press any key
                WriteLine(ex.Message);
            }
        }
    }
}
