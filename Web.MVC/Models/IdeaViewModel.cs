using Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.MVC.Models
{
    public class IdeaViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UniqueCode { get; set; }
        public UserDTO User { get; set; }
    }
}
