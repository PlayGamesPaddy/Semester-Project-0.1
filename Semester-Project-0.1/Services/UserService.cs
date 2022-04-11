using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Semester_Project_0._1.Data;
using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Services
{
    public class UserService : InterfaceUserService
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;
        public UserService(ApplicationDBContext db, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _HttpContextAccessor = httpContextAccessor;
            loginUserId = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            _userManager = userManager;
        }
        public string GetUserName(string UserId)
        {
            return _userManager.Users.FirstOrDefault(u => u.Id == UserId).FullName;
        }

        public ApplicationUser GetUser()
        {
            ApplicationUser user = new ApplicationUser();
            user = _userManager.Users.FirstOrDefault(u => u.Id == loginUserId);
            return user;
        }
        public ApplicationUser GetUser(string IDIn)
        {
            ApplicationUser user = new ApplicationUser();
            user = _userManager.Users.FirstOrDefault(u => u.Id == IDIn);
            return user;
        }

        public List<StudentVM> GetUsersStudents()
        {
            var students = (from student in _db.Students.Where(x => x.PrimaryGuardian == loginUserId)
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
    }
}
