using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semester_Project_0._1.Data;
using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using Semester_Project_0._1.Services;
using Semester_Project_0._1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Controllers
{
    [Authorize(Roles = Helper.Instructure + "," + Helper.Admin)]
    public class InstructorController : Controller
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string loginUserId;
        private readonly ApplicationDBContext _db;
        private readonly IClassService _classService;
        public InstructorController(ApplicationDBContext db, IClassService classService, IHttpContextAccessor httpContextAccessor)
        {
            _classService = classService;
            _db = db;
            _HttpContextAccessor = httpContextAccessor;
            loginUserId = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public IActionResult InstructorClassMenu()
        {

            ViewBag.Duration = Helper.GetTimeDropDown();
            List<RecurringClassInstent> RCI = _db.RecurringClasses.Where(rcl => rcl.InstructerId == loginUserId).ToList();
            IEnumerable<InstructorVM> IVM = _db.Users.Where(u=>u.Id== loginUserId).ToList().Select(IVM=>new InstructorVM()
            {
               FirstName = IVM.FullName,
               Id = IVM.Id,
                InstructorRecurringClassList = RCI,
                //LastName 
                //FullName 
                //ApplicationUser 
                UserAccount = _db.Users.Find(loginUserId)
        }).ToList();
            //IVM.InstructorRecurringClassList = _db.RecurringClasses.Where(rcl => rcl.InstructerId == loginUserId).ToList();
            return View(IVM);
        }
    }
}
