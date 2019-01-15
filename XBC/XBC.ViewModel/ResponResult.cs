using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBC.ViewModel
{
    public class ResponResult
    {
        public ResponResult()
        {
            Sucsess = true;
        }
        public bool Sucsess { get; set; }
        public string Message { get; set; }
        public object Entity { get; set; }
        public string Reference { get; set; }
    }
}
