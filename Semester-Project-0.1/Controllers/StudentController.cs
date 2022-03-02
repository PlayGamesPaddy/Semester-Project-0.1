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

namespace Semester_Project_0._1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objList = _db.Students;
            foreach(var obj in objList)
            {
                obj.StudentType = _db.StudentTypes.FirstOrDefault(u => u.Id == obj.StudentTypeId);
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
        public IActionResult DeletePost(StudentVM studentId)
        {
            var obj = _db.Students.Find(studentId.Student.StudentId);
            if (obj == null)
            {
                return NotFound();
            }
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
