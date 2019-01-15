using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBC.ViewModel
{
    public class ResponResultViewModel
    {
        public ResponResultViewModel()
        {
            Success = true;
            Message = "No message";
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Entity { get; set; }
    }
}
