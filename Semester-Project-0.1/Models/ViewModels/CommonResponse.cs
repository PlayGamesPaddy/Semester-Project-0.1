using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Models.ViewModels
{
    public class CommonResponse<T>
    {
        public int status { get; set; }
        public string message { set; get; }
        public T datenum { get; set; }
    }
}
