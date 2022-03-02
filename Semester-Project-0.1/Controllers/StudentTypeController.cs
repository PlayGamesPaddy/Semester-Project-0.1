using Microsoft.AspNetCore.Mvc;
using Semester_Project_0._1.Data;
using Semester_Project_0._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Controllers
{
    public class StudentTypeController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StudentTypeController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<StudentType> objList = _db.StudentTypes;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentType obj)
        {
            if (ModelState.IsValid)
            {
                _db.StudentTypes.Add(obj);
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
            var obj = _db.StudentTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);


        }
        //post delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.StudentTypes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.StudentTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.StudentTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //post update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(StudentType obj)
        {
            if (ModelState.IsValid)
            {
                _db.StudentTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
