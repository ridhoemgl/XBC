using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBC.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "USERNAME")]
        public string username { get; set; }

        [Required]
        [Display(Name = "PASSWORD")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
