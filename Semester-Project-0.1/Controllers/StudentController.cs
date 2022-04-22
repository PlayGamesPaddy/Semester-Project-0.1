using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Semester_Project_0._1.Data;
using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Semester_Project_0._1.Services;

namespace Semester_Project_0._1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string loginUserId;
        private readonly ApplicationDBContext _db;
        private readonly IClassService _classService;
        public StudentController(ApplicationDBContext db, IHttpContextAccessor httpContextAccessor, IClassService classService)
        {
            _classService = classService;
            _db = db;
            _HttpContextAccessor = httpContextAccessor;
            loginUserId = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public IActionResult Index()
        {
            IEnumerable<StudentVM> objList = _db.Students.ToList().Select(c => new StudentVM()
            {
                Student = c,
                StudentId = c.StudentId,
                StudentNameFirst = c.StudentNameFirst,
                StudentNameLast = c.StudentNameLast,
                StudentNameFull=c.StudentNameFirst +" "+ c.StudentNameLast,
                PrimaryGuardian = c.PrimaryGuardian
            }).ToList(); 
            foreach(var obj in objList)
            {
                obj.recurringClassList = _classService.GetStudentsRecurringClassList(obj.StudentId);
                obj.Student.StudentType = _db.StudentTypes.FirstOrDefault(u => u.Id == obj.Student.StudentTypeId);
                obj.classStudentList = _db.ClassStudentList.Where(s=> s.studentId == obj.StudentId).ToList();
            }
            return View(objList);
        }
        //get-create
        //reterns the view
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _db.StudentTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});
            //ViewBag.TypeDropDown = TypeDropDown;
            StudentVM studenVM = new StudentVM()
            {
                Student = new Student(),
                TypeDropDown = _db.StudentTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(studenVM);

        }
        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentVM obj)
        {
            if (ModelState.IsValid)
            {
                obj.Student.PrimaryGuardian = loginUserId;
                _db.Students.Add(obj.Student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //get delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            StudentVM studentVM = new StudentVM()
            {
                Student = new Student(),
                TypeDropDown = _db.StudentTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            studentVM.Student = _db.Students.Find(id);
            return View(studentVM);


        }
        //post delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(StudentVM studentIn)
        {
            var obj = _db.Students.Find(studentIn.Student.StudentId);
            if (obj == null)
            {
                return NotFound();
            }
            //working hear need to dele the student list frst
            //< list > ClassStudentList classStudentList = new < List > ClassStudentList()
            studentIn.classStudentList = _db.ClassStudentList.Where(cSL => cSL.studentId == studentIn.Student.StudentId).ToList();
            _db.ClassStudentList.RemoveRange(studentIn.classStudentList);
            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get update
        public IActionResult Update(int? id)
        {
            StudentVM studenVM = new StudentVM()
            {
                Student = new Student(),
                TypeDropDown = _db.StudentTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }
            studenVM.Student = _db.Students.Find(id);
            if(studenVM == null)
            {
                return NotFound();
            }
            return View(studenVM);
        }
        //post update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(StudentVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj.Student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
