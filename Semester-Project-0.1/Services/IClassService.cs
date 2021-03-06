using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Services
{
    public interface IClassService
    {
        public List<InstructorVM> GetInstructureList();
        public List<UserVM> GetUserList();

        public List<StudentVM> GetStudentList();
        public Task<int> AddUpdate(ClassVM model);
        public List<ClassVM> InstructureEventsById(string InstructerId);
        public List<ClassVM> StudentEventsByRecurringClassId(int recurringClassId);
        public List<ClassVM> StudentEventsById(int StudentId);
        public ClassVM GetById(int id);
        public Task<int> Delete(int id);
        public Task<int> ConfirmEvent(int id);
        public List<ClassVM> UserStudentClasslist(string id);
        public List<RecurringClassInstent> GetStudentsRecurringClassList(int id);
    }
}
