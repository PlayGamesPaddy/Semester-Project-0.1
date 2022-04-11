using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Models
{
    public class ClassInstent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string InstructerId { get; set; }
        // StudentId temp will need to change to reference to student list
        public int StudentId { get; set; }
        public bool IsApproved { set; get; }
        public string AdminId { get; set; }
        public int? RecurringClassInstentId { get; set; }
        public RecurringClassInstent RecurringClassInstent { get; set; }

    }
}
