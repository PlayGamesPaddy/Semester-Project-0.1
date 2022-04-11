using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Semester_Project_0._1.Services;
using Semester_Project_0._1.Utility;
using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semester_Project_0._1.Data;


namespace Semester_Project_0._1.Controllers
{

    [Authorize]
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly ApplicationDBContext _db;
        private readonly InterfaceUserService _userService;
        public InterfaceRecurringClassService _RCService;

        public ClassController(IClassService classService, ApplicationDBContext db, InterfaceUserService UserService, InterfaceRecurringClassService RecurringClassService)
        {
            _classService = classService;
            _db = db;
            _userService = UserService;
            _RCService = RecurringClassService;
        }
        //[Authorize(Roles = Helper.Admin)]
        public IActionResult Index()
        {
            ViewBag.InstuctureList = _classService.GetInstructureList();
            //ViewBag.Studentlist = _userService.GetUsersStudents();
            ViewBag.Duration = Helper.GetTimeDropDown();
            return View();
            //String todaysDate = DateTime.Now.ToShortDateString();
            //return Ok(todaysDate);
        }

        public IActionResult Details(int id)
        {
            //return View();
            //String todaysDate = DateTime.Now.ToShortDateString();
            return Ok("YOu have entered id = " + id);
        }
        //creath
        public IActionResult RecurringClassSetup()
        {

            ViewBag.InstuctureList = _classService.GetInstructureList();
            ViewBag.Duration = Helper.GetTimeDropDown();
            ViewBag.Days = Helper.DaysOfTheWeek();
            ViewBag.WeekOfTheMonth = Helper.WeekOfTheMonth();
            return View();
        }
        //list
        public IActionResult RecurringClassIndex() {

            ViewBag.studentList = _userService.GetUsersStudents();
            IEnumerable<RecurringClassInstent> objList = _db.RecurringClasses.OrderByDescending(item=>item.FirstClassDate);
            foreach(var rC in objList)
            {
                List<ClassStudentList> iecl = _db.ClassStudentList.Where(x => x.recurringClassInstentId == rC.Id).ToList();
                rC.StudentList = iecl;
            }
            IEnumerable<ClassStudentList> CSL = _db.ClassStudentList;
            return View(objList);
        }

        public IActionResult RecurringClassDelete(int? id)
        {
            RecurringClassInstent obj = _db.RecurringClasses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            IEnumerable<ClassInstent> classes = _db.Classes.Where(x=>x.RecurringClassInstentId == obj.Id);
            if (classes != null)
            {
                foreach (var c in classes)
                {
                    _db.Classes.Remove(c);
                }
            }
            IEnumerable<ClassStudentList> CST = _db.ClassStudentList.Where(x => x.recurringClassInstentId == obj.Id);
            if (CST != null)
            {
                foreach (var c in CST)
                {

                    IEnumerable<ClassStudentComment> CSC = _db.ClassStudentComment.Where(x => x.ClassStudentListid == c.id);
                    if (CSC != null)
                    {
                        foreach (var comment in CSC)
                        {
                            _db.ClassStudentComment.Remove(comment);
                        }
                    }



                    _db.ClassStudentList.Remove(c);
                }
            }
            
            //var classes = _db.Classes.Where(c=>c.RecurringClassInstent = obj.Id)
            _db.RecurringClasses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("RecurringClassIndex");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult RecurringClassInfo(int? id)
        {
            ViewBag.studentList = _userService.GetUsersStudents();
            ViewBag.InstuctureList = _classService.GetInstructureList();
            ViewBag.Duration = Helper.GetTimeDropDown();
            RecurringClassInstentVM recurringClassInstentVM = new RecurringClassInstentVM();
            recurringClassInstentVM.recurringClassInstent = _db.RecurringClasses.Find(id);
            recurringClassInstentVM.Instructer = _db.Users.Find(recurringClassInstentVM.recurringClassInstent.InstructerId);
            //st<ClassInstent> classes = new List<ClassInstent>();
            //List<ClassStudentList>
            List<ClassStudentList> iecl = _db.ClassStudentList.Where(x => x.recurringClassInstentId == id).ToList();
            foreach (ClassStudentList CS in iecl)
            {
                CS.student = _db.Students.Find(CS.studentId);
            }
            recurringClassInstentVM.StudentList = iecl;
            recurringClassInstentVM.Classlist = _db.Classes.Where(x => x.RecurringClassInstentId == id).ToList();
            //IEnumerable<ClassInstent> classes = _db.Classes.Where(x => x.RecurringClassInstentId == id);
            return View(recurringClassInstentVM);
        }
        public IActionResult StudentNotes(int? id)
        {
            StudentClassVM classStudentNotes = new StudentClassVM();
            classStudentNotes.classStudentList = _db.ClassStudentList.Find(id);
            classStudentNotes.student = _db.Students.Find(classStudentNotes.classStudentList.studentId);
            classStudentNotes.recurringClassInstent = _db.RecurringClasses.Find(classStudentNotes.classStudentList.recurringClassInstent);
            classStudentNotes.classStudentComments = _db.ClassStudentComment.Where(x=>x.ClassStudentListid== classStudentNotes.classStudentList.id).ToList();
            foreach (ClassStudentComment CSC in classStudentNotes.classStudentComments)
            {
                CSC.commentator = _userService.GetUser(CSC.commentatorId);
            }
                //new StudentClassVM();
            return View(classStudentNotes);
        }
    }
}
