using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Services
{
    public interface InterfaceUserService
    {
        public List<StudentVM> GetUsersStudents();
        public string GetUserName(string UserId);
        public ApplicationUser GetUser();
        public ApplicationUser GetUser(string IDIn);
    }
}
