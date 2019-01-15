using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XBC.MVC.WebApp.Models
{
    public class UserAccount
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirsName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
       
        public string email { get; set; }   
        public string ConfirmPassword { get; set; }
    }
}