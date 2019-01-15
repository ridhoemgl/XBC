using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBC.ViewModel
{
    public class MenuAccessViewModel
    {
        [Required]
        
        public long id { get; set; }
        [Required]
        public long menu_id { get; set; }
        [Required]
        public long role_id { get; set; }
        [Required]
        [Display(Name ="Menu")]
        public string title { get; set; }
        [Required]
        [Display(Name ="Role")]
        public string role { get; set; }

    }
}
