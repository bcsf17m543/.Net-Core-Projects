using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Blog_Application.Models
{
    public class PublicUser
    {
      
        public int id { get; set; } //readOnly
        [Required(ErrorMessage = "Please enter email")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "please enter password")]
        [StringLength(8)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "please enter your phone")]
      // [Phone(ErrorMessage ="Please Enter Correct Phone Number")]
        public long? Phone { get; set; } 

       
        public bool IsCorrectNumber(long? phone)
        {
            string ph = phone.ToString();
            if(ph.Length>11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
