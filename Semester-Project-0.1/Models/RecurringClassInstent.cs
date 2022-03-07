using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Models
{
    public class RecurringClassInstent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime FirstClassDate { get; set; }
        public DateTime LastClassDate { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string InstructerId { get; set; }
        public ApplicationUser Instructer { set; get; }
        // StudentId temp will need to change to reference to student list
        public List<Student> Students { get; set; }
        public List<ClassInstent> Classlist { set; get; }
        public string RecurringType { get; set; }
        //public bool IsApproved { set; get; }
        //public string AdminId { get; set; }

    }
}
