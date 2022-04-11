using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Models
{
    public class ClassRoster
    {//planing to maybe use this for rolecalls to see what students are present or indevidule classes
        public int Id { set; get; }
        public bool present { set; get; }
        public ClassInstent classInstent { set; get; }
        public int? classInstentId { set; get; }
        public RecurringClassInstent recurringClassInstent { set; get; }
        public int? recurringClassInstentId{ set; get; }

    }
}
