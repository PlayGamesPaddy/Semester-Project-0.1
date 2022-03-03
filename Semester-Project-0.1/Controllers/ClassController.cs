using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Semester_Project_0._1.Services;
using Semester_Project_0._1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Controllers
{

    [Authorize]
    public class ClassController : Controller
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
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
    }
}
