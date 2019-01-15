using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBC.ViewModel
{

    public class AccountViewModel
    {
        public AccountViewModel()
        {
            is_delete = false;
        }
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

        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [Display(Name = "Retype Password")]
        public string ConfirmPassword { get; set; }

        public AccountViewModel find(string userName)
        {
            throw new NotImplementedException();
        }

        [Display(Name = "ROLE")]
        public long role_id { get; set; }

        public string role_name { get; set; }

        [Display(Name = "Mobile Flag")]
        public bool mobile_flag { get; set; }

        [Display(Name = "Mobile Flag")]
        public long? mobile_token { get; set; }

        [Display(Name = "STATUS")]
        public bool is_delete { get; set; }

        public string status
        {
            get
            {
                if (is_delete == false)
                {
                    return "Active";
                }
                else
                {
                    return "Deactive";
                }
            }
        }
        public List<string> Roles { get; set; }
    }

    public class PrivilageViewModel
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Controller { get; set; }
        public string Menu { get; set; }
        public string AccessRight { get; set; }
        public int Child { get; set; }
    }

    public class ChangePasswordViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} char length", MinimumLength = 6)]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} char length", MinimumLength = 6)]
        [Display(Name = "Confirm New Password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation do not match")]
        public string ConfirmPassword { get; set; }
    }

}
