using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Semester_Project_0._1.Models.ViewModels
{
    public class InstructorVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public ApplicationUser UserAccount { get; set; }
        public List<RecurringClassInstent> InstructorRecurringClassList { get; set; }
    }
}
