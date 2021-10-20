using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.MVC.Models
{
    public class AddIdeaViewModel
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
