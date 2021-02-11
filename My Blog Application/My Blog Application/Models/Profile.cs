using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Blog_Application.Models
{
    public class Profile
    {
        [Required(ErrorMessage ="Please Enter data")]
        public PublicUser Usrinfo { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress]
        public string Emailaddress { get; set; }
        [Required(ErrorMessage = "Please enter the Image Path")]
        public string ImagePath { get; set; }

    }
}
