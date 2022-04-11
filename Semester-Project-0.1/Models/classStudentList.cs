using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Models
{
    public class ClassStudentList
    {
        public int id { get; set; }
        public int? studentId { get; set; }
        public Student student { get; set; }
        public int? recurringClassInstentId { get; set; }
        public RecurringClassInstent recurringClassInstent { get; set; }
        public List<ClassStudentComment> classStudentComments { get; set; }
    }
}
