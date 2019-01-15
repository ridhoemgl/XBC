using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBC.ViewModel
{
    public class ResetPassword
    {
        public long id { get; set; }

        [Required]
        [Display(Name = "USERNAME")]
        [MaxLength(50)]
        public String username { get; set; }

        [Required]
        [Display(Name = "New PASSWORD")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        public String password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Retype Password")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public String ConfirmPassword { get; set; }
    }
}
