using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
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
    public class ClassService : IClassService
    {
        private readonly ApplicationDBContext _db;
        private readonly IEmailSender _emailSender;
        //private readonly IClassService _classService;
        public ClassService(ApplicationDBContext db, IEmailSender emailSender)
        {
            _db = db;
            _emailSender = emailSender;
            //ViewBag.Studentlist = _classService.GetStudentList();
        }
        public List<InstructorVM> GetInstructureList()
        {
            var instructures = (from user in _db.Users
                                join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                                join roles in _db.Roles.Where(x => x.Name == Helper.Instructure) on userRoles.RoleId equals roles.Id
                                select new InstructorVM
                                {
                                    Id = user.Id,
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
                                    FullName = user.FullName
                                }
                ).ToList();
            return instructures;
        }

        public List<UserVM> GetUserList()
        {
            var users = (from user in _db.Users
                         join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                         join roles in _db.Roles.Where(x => x.Name == Helper.User) on userRoles.RoleId equals roles.Id
                         select new UserVM
                         {
                             Id = user.Id,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             FullName = user.FullName
                         }
                ).ToList();
            return users;
        }
        public List<StudentVM> GetStudentList()
        {
            var students = (from student in _db.Students
                            select new StudentVM
                            {
                                Student = student,
                                StudentId = student.StudentId,
                                StudentNameFirst = student.StudentNameFirst,
                                StudentNameLast = student.StudentNameLast,
                                StudentNameFull = student.StudentNameFirst + " " + student.StudentNameLast
                            }
                ).ToList();
            return students;
        }

        /*public Task<int> AddUpdate(ClassVM model)
       {
           throw new NotImplementedException();
       }*/

       public async Task<int> AddUpdate(ClassVM model)
       {
           var startDate = DateTime.Parse(model.StartDate);
           var endDate = DateTime.Parse(model.StartDate).AddMinutes(Convert.ToDouble(model.Duration));
            string InId;
            if (model.InstructerId == null)
            {
                //InId = TempData["instructerId"].toString();
            }
            else
            {
                InId = model.InstructerId;
            }
            //var Instructer = _db.Users.FirstOrDefault(u=>u.Id == model.InstructerId);
            //var student = _db.Students.FirstOrDefault(u => u.StudentId == model.StudentId);
            if (model != null && model.Id > 0)
           {
                //update
                var classInstent = _db.Classes.FirstOrDefault(x => x.Id == model.Id);
                classInstent.Title = model.Title;
                classInstent.Description = model.Description;
                classInstent.StartDate = startDate;
                classInstent.EndDate = endDate;
                classInstent.Duration = model.Duration;
                classInstent.RecurringClassInstentId = model.RecurringClassInstentId;
                //classInstent.InstructerId = model.InstructerId;
                // StudentId temp will need to change to reference to student list
                //classInstent.StudentId = model.StudentId;
                //classInstent.IsApproved = model.IsApproved;
                //classInstent.AdminId = model.AdminId;
                await _db.SaveChangesAsync();


                return 1;
           }
           else
           {
                //create
                ClassInstent classI = new ClassInstent()
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = model.Duration,
                    InstructerId = model.InstructerId,
                    // StudentId temp will need to change to reference to student list
                    //StudentId = model.StudentId,
                    IsApproved = model.IsApproved,
                    AdminId = model.AdminId,
                    RecurringClassInstentId = model.RecurringClassInstentId
                };
                /*await _emailSender.SendEmailAsync(Instructer.Email, "Class Made",
                    $"class has been made With{student.StudentNameFirst} {student.StudentNameLast} is created and pending status");
                await _emailSender.SendEmailAsync(student.StudentEmail, "Class Made",
                    $"class has been made With {Instructer.FullName} created and pending status");*/
                _db.Classes.Add(classI);
               await _db.SaveChangesAsync();
                return 2;
           }
       }

        public List<ClassVM> InstructureEventsById(string InstructerId)
        {

            return _db.Classes.Where(x => x.InstructerId == InstructerId).ToList().Select(c => new ClassVM()
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsApproved=c.IsApproved,
                InstructerId=c.InstructerId
            }).ToList();
        }

        public List<ClassVM> StudentEventsById(int StudentId)
        {
            return _db.Classes.Where(x => x.StudentId == StudentId).ToList().Select(c => new ClassVM()
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsApproved = c.IsApproved
            }).ToList();
        }

        public List<ClassVM> StudentEventsByRecurringClassId(int recurringClassId)
        {
            return _db.Classes.Where(x => x.RecurringClassInstentId == recurringClassId).ToList().Select(c => new ClassVM()
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsApproved = c.IsApproved
            }).ToList();
        }

        public ClassVM GetById(int id)
        {
            return _db.Classes.Where(x => x.Id == id).ToList().Select(c => new ClassVM()
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsApproved = c.IsApproved,
                StudentId=c.StudentId,
                InstructerId=c.InstructerId,
                StudentName = _db.Students.Where(x => x.StudentId == c.StudentId).Select(x => x.StudentNameLast).FirstOrDefault(),
                InstructureName = _db.Users.Where(x => x.Id == c.InstructerId).Select(x => x.FullName).FirstOrDefault(),
            }).SingleOrDefault();
        }

        public async Task<int> Delete(int id)
        {
            ClassInstent classInstence = _db.Classes.FirstOrDefault(x => x.Id == id);
            //(List<RecurringClassInstent>)_db.RecurringClasses.Where(rc=>rc.Id==classStudentList.recurringClassInstentId).ToList();//classInstence.RecurringClassInstent = _db.RecurringClasses.Find(classInstence.RecurringClassInstentId);
            if (classInstence != null)
            {
                List<ClassStudentList> iecl = _db.ClassStudentList.Where(x => x.recurringClassInstentId == classInstence.RecurringClassInstentId).ToList();
                foreach (ClassStudentList cSL in iecl)
                {
                    cSL.student = _db.Students.Find(cSL.studentId);
                    await _emailSender.SendEmailAsync(cSL.student.StudentEmail, "Class Canceled",
                        $"{classInstence.Title} on {classInstence.StartDate} Has been Canceled.");
                }
                _db.Classes.Remove(classInstence);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> ConfirmEvent(int id)
        {
            var classInstence = _db.Classes.FirstOrDefault(x => x.Id == id);
            if (classInstence != null)
            {
                classInstence.IsApproved = true;
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public List<ClassVM> UserStudentClasslist(string id)
        {
            List <Student> students = _db.Students.Where(u=>u.PrimaryGuardian==id).ToList();
            List<ClassStudentList> CSL = new List<ClassStudentList>();
            List<ClassVM> classList = new List<ClassVM>();
            List<RecurringClassInstent> RCI = new List<RecurringClassInstent>();
            foreach( var Student in students)
            {
                if (CSL.Count() < 1)
                {
                    CSL = (List<ClassStudentList>)_db.ClassStudentList.Where(cl => cl.studentId == Student.StudentId).ToList();
                }
                else
                {
                    CSL.AddRange((List<ClassStudentList>)_db.ClassStudentList.Where(cl => cl.studentId == Student.StudentId).ToList());
                }
                
            }
            foreach (var classStudentList in CSL)
            {
                if (RCI.Count()<1)
                {
                    RCI = (List<RecurringClassInstent>)_db.RecurringClasses.Where(rc=>rc.Id==classStudentList.recurringClassInstentId).ToList();
                }
                else
                {
                    RCI.AddRange((List<RecurringClassInstent>)_db.RecurringClasses.Where(rc => rc.Id == classStudentList.recurringClassInstentId).ToList());
                }
            }
            foreach (var RC in RCI)
            {
                if (classList.Count()<1)
                {
                    classList = StudentEventsByRecurringClassId(RC.Id);
                        //(List<ClassInstent>)_db.Classes.Where(classVM => classVM.RecurringClassInstentId==RC.Id).ToList();
                }
                else
                {
                    classList.AddRange(StudentEventsByRecurringClassId(RC.Id));
                        //(List<ClassInstent>)_db.Classes.Where(classVM => classVM.RecurringClassInstentId == RC.Id).ToList());
                }
            }
            return classList.Distinct().ToList(); ;
        }

        public List<RecurringClassInstent> GetStudentsRecurringClassList(int id)
        {
            List<ClassStudentList> CSL = new List<ClassStudentList>();
            List<RecurringClassInstent> RCI = new List<RecurringClassInstent>();
            CSL = (List<ClassStudentList>)_db.ClassStudentList.Where(cl => cl.studentId == id).ToList();
            foreach (var classStudentList in CSL)
            {
                if (RCI.Count() < 1)
                {
                    RCI = (List<RecurringClassInstent>)_db.RecurringClasses.Where(rc => rc.Id == classStudentList.recurringClassInstentId).ToList();
                }
                else
                {
                    RCI.AddRange((List<RecurringClassInstent>)_db.RecurringClasses.Where(rc => rc.Id == classStudentList.recurringClassInstentId).ToList());
                }
            }
            return RCI;
        }
    }
}
/*StudentEventsByRecurringClassId(int recurringClassId)*/