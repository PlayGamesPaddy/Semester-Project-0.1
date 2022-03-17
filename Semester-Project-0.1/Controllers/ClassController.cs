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

        public ClassController(IClassService classService, ApplicationDBContext db)
        {
            _classService = classService;
            _db = db;
        }
        //[Authorize(Roles = Helper.Admin)]
        public IActionResult Index()
        {
            ViewBag.InstuctureList = _classService.GetInstructureList();
            ViewBag.Studentlist = _classService.GetStudentList();
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

        public IActionResult RecurringClassSetup()
        {

            ViewBag.InstuctureList = _classService.GetInstructureList();
            ViewBag.Duration = Helper.GetTimeDropDown();
            ViewBag.Days = Helper.DaysOfTheWeek();
            ViewBag.WeekOfTheMonth = Helper.WeekOfTheMonth();
            return View();
        }

        public IActionResult RecurringClassIndex() {
            IEnumerable<RecurringClassInstent> objList = _db.RecurringClasses;
            return View(objList);
        }
    }
}
