using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Services
{
    public interface InterfaceRecurringClassService
    {
        public Task<int> AddUpdate(RecurringClassInstentVM model);
        public Task<int> EnroleStudent(ClassStudentList model);
        public Task<int> AddComment(ClassStudentComment model);
        public Task<int> UnEnroleStudent(ClassStudentList Id);
        public int GetStudentCount(int RCid);

        public Task<int> RClassUpdate(RecurringClassInstentVM RCI);
    }
}
