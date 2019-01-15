using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBC.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            is_delete = false;
        }
        //public long id { get; set; }
        //[Required]
        //[StringLength(50)]
        //[Display(Name = "USERNAME")]
        //public string username { get; set; }

        //[Required]
        //[StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        //[Display(Name = "PASSWORD")]
        //public string password { get; set; }

        //[Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        //[Display(Name = "Retype Password")]
        //public string Retype_password { get; set; }

        //[Display(Name = "ROLE")]
        //public long role_id { get; set; }

        //[Display(Name = "ROLE")]
        //public string role_name { get; set; }

        //[Display(Name = "Mobile Flag")]
        //public bool mobile_flag { get; set; }

        //[Display(Name = "Mobile Flag")]
        //public long? mobile_token { get; set; }

        //[Display(Name = "STATUS")]
        //public bool active { get; set; }

        //public string status
        //{
        //    get
        //    {
        //        if (active == true)
        //        {
        //            return "Active";
        //        }
        //        else
        //        {
        //            return "Deactive";
        //        }
        //    }
        //}
        public long id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "USERNAME")]
        public string username { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [Display(Name = "PASSWORD")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "ROLE")]
        public long role_id { get; set; }

        [Display(Name = "ROLE")]
        public string name { get; set; }

        [Display(Name = "Mobile Flag")]
        public bool mobile_flag { get; set; }

        [Display(Name = "Mobile Token")]
        public long? mobile_token { get; set; }

        [Display(Name ="Hapus")]
        public bool is_delete { get; set; }
        public string status { get
            {
                if (is_delete== false)
                {
                    return "False";
                }
                else
                {
                    return "True";
                }
            }
        }
    }
    public class RegisterViewModel
    {
        public long id { get; set; }

        public long role_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "ROLE")]
        public string name { get; set; }


        [Required]
        
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
