using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Blog_Application.Models
{
    public class Blog
    {
        public int blog_Id { get; set; }

        [Required(ErrorMessage = "Please enter Title")]
        [StringLength(30)]
        public string Title { get; set; }
        [Required(ErrorMessage = "please enter Content")]
        [StringLength(250)]
        public string Content { get; set; }

        [StringLength(20)]
        public string Date { get; set; }

      
    }
}
