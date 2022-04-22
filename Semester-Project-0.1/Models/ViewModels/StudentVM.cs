using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Models.ViewModels
{
    public class StudentVM
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public string StudentNameFirst { get; set; }
        public string StudentNameLast { set; get; }
        public string StudentNameFull { set; get; }
        public string PrimaryGuardian { set; get; }

        public IEnumerable<SelectListItem> TypeDropDown { get; set; }

        public List<RecurringClassInstent> recurringClassList { get; set; }

        public List<ClassStudentList> classStudentList { get; set; }
    }
}
