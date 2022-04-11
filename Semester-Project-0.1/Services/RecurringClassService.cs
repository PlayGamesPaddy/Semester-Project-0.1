using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Semester_Project_0._1.Data;
using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using Semester_Project_0._1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Services
{
    public class RecurringClassService : InterfaceRecurringClassService
    {
        private readonly ApplicationDBContext _db;
        private readonly IEmailSender _emailSender;
        private readonly InterfaceUserService _userService;

        public RecurringClassService(ApplicationDBContext db, IEmailSender emailSender, InterfaceUserService UserService)
        {
            _db = db;
            _emailSender = emailSender;
            _userService = UserService;
        }

        public async Task<int> AddUpdate(RecurringClassInstentVM model)
        {
            var firstDate = DateTime.Parse(model.FirstClassDate);
            var lastDate = DateTime.Parse(model.LastClassDate);
            if (true)
            {

            }
            else
            {

            }
            var Instructer = _db.Users.FirstOrDefault(u => u.Id == model.InstructerId);
            RecurringClassInstent recurringClass = new RecurringClassInstent()
            {
                Title = model.Title,
                FirstClassDate = firstDate,
                LastClassDate = lastDate,
                Description = model.Description,
                Duration = model.Duration,
                InstructerId = model.InstructerId,
                Instructer = model.Instructer,
                RecurringType = model.RecurringType,
                Classlist = model.Classlist,
                MaxNumberOfStudents=model.MaxNumberOfStudents
            };
            //List<ClassInstent>  classlist;
            
            _db.RecurringClasses.Add(recurringClass);
            await _db.SaveChangesAsync();
            int newId = recurringClass.Id;
            return newId;
            //return 2;
        }
        public async Task<int> Delete(int id)
        {
            var recurringClass = _db.RecurringClasses.FirstOrDefault(x => x.Id == id);
            if (recurringClass != null)
            {
                _db.RecurringClasses.Remove(recurringClass);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> UnEnroleStudent(int Id)
        {
            var classStudent = _db.ClassStudentList.FirstOrDefault(x => x.id == Id);
            if (classStudent != null)
            {
                _db.ClassStudentList.Remove(classStudent);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> EnroleStudent(ClassStudentList model)
        {
            ClassStudentList classStudent1 = new ClassStudentList()
            {
                studentId = model.studentId,
                recurringClassInstentId = model.recurringClassInstentId
            };
            //_db.classStudentList.Add(classStudent1);
            //Student enrolledStudent = _db.Students.Find(model.studentId);
            //RecurringClassInstent rci = _db.RecurringClasses.Find(model.recurringClassInstentId);

            //rci.StudentList.Add(model);

            RecurringClassInstent rci = _db.RecurringClasses.Find(model.recurringClassInstentId);
            classStudent1.recurringClassInstent = rci;
            classStudent1.student = _db.Students.Find(model.studentId);
            if (rci.StudentList==null)
            {
                List<ClassStudentList> scList = new List<ClassStudentList>();
                scList.Add(classStudent1);
                rci.StudentList = scList;
            }
            else
            {
                rci.StudentList.Add(classStudent1);
            }
            await _db.SaveChangesAsync();
            return 2;
        }
        public async Task<int> AddComment(ClassStudentComment model)
        {
            //var DateIn = DateTime.Parse(model.CommentDate);
            ClassStudentComment classStudentComment = new ClassStudentComment() {
                ClassStudentList = _db.ClassStudentList.Find(model.ClassStudentListid),
                Text = model.Text,
                CommentDate = DateTime.Now,
                commentator = _userService.GetUser()
            };
            ClassStudentList CSL = new ClassStudentList();
            CSL = _db.ClassStudentList.Find(model.ClassStudentListid);
            if (CSL.classStudentComments==null)
            {
                List<ClassStudentComment> commentlist = new List<ClassStudentComment>();
                commentlist.Add(classStudentComment);
                CSL.classStudentComments = commentlist;
            }
            else
            {
                CSL.classStudentComments.Add(classStudentComment);
            }
            await _db.SaveChangesAsync();
            return 2;
        }
    }


}
