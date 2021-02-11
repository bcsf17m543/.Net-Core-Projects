using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Blog_Application.Models
{
    public class Admin
    {
        [Required(ErrorMessage = "Please enter Admin Code.")]
        public string Code { get; set; }
    }
}
