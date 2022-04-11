using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using Semester_Project_0._1.Services;
using Semester_Project_0._1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Controllers.Api
{
    [Route("api/RecurringClassSetup")]
    [ApiController]
    public class RecurringClassApiController : Controller
    {
        private readonly IClassService _classService;
        private readonly InterfaceRecurringClassService _RecurringClassService;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;

        public RecurringClassApiController(IClassService classService, InterfaceRecurringClassService recurringClassService, IHttpContextAccessor httpContextAccessor)
        {
            _RecurringClassService = recurringClassService;
            _classService = classService;
            _HttpContextAccessor = httpContextAccessor;
            loginUserId = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        }

        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(RecurringClassContainer data)
        {
            //, List<String> requestDataDays//RecurringClassInstentVM 
            RecurringClassInstentVM recurringClassInstentVM = new RecurringClassInstentVM();

            recurringClassInstentVM.Title = data.Title;
            recurringClassInstentVM.FirstClassDate = data.FirstClassDate;
            recurringClassInstentVM.LastClassDate = data.LastClassDate;
            recurringClassInstentVM.Description = data.Description;
            recurringClassInstentVM.Duration = data.Duration;
            recurringClassInstentVM.MaxNumberOfStudents = data.MaxNumberOfStudents;
            if (data.InstructerId == null || data.InstructerId == "")
            {
                recurringClassInstentVM.InstructerId = loginUserId;
                data.InstructerId = loginUserId;
            }
            else { 
                recurringClassInstentVM.InstructerId = data.InstructerId;
            }
            recurringClassInstentVM.RecurringType = data.RecurringType;
            if (recurringClassInstentVM.RecurringType == "weekly")
            {
                recurringClassInstentVM.Classlist = MakeClassList(data,7, data.weeklytimepicer, data.weeklyday);
            }
            else if (recurringClassInstentVM.RecurringType == "everySecondWeek")
            {
                recurringClassInstentVM.Classlist = MakeClassList(data,14, data.secondweeklytimepicer, data.secondweekdaysoftheweekradio);
            }
            else if (recurringClassInstentVM.RecurringType == "onceAMounth")
            {
                recurringClassInstentVM.Classlist = MakeClassList(data, 28, data.mounthtimepicer, data.onceaMonthradio);
            }
            else if (recurringClassInstentVM.RecurringType == "multibleDaysAWeek")
            {
                recurringClassInstentVM.Classlist = new List<ClassInstent>();
                if (data.cbMonday)
                {
                    recurringClassInstentVM.Classlist.AddRange(MakeClassList(data, 7, data.montimepicker,"Monday"));
                }
                if (data.cbTuesday)
                {
                    recurringClassInstentVM.Classlist.AddRange(MakeClassList(data, 7, data.tuetimepicker, "Tuesday"));
                }
                if (data.cbWednesday)
                {
                    recurringClassInstentVM.Classlist.AddRange(MakeClassList(data, 7, data.wentimepicker, "Wednesday"));
                }
                if (data.cbThursday)
                {
                    recurringClassInstentVM.Classlist.AddRange(MakeClassList(data, 7, data.thutimepicker, "Thursday"));
                }
                if (data.cbFriday)
                {
                    recurringClassInstentVM.Classlist.AddRange(MakeClassList(data, 7, data.fritimepicker, "Friday"));
                }
                if (data.cbSaturday)
                {
                    recurringClassInstentVM.Classlist.AddRange(MakeClassList(data, 7, data.sattimepicker, "Saturday"));
                }
                if (data.cbSunday)
                {
                    recurringClassInstentVM.Classlist.AddRange(MakeClassList(data, 7, data.suntimepicker, "Sunday"));
                }
            }

            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _RecurringClassService.AddUpdate(recurringClassInstentVM).Result;
                /*if (commonResponse.status == 1)
                {
                    commonResponse.message = Helper.classUpdated;
                }
                if (commonResponse.status == 2)
                {
                    commonResponse.message = Helper.classAdded;
                }*/
                commonResponse.message = Helper.classAdded;
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }
            //commonResponse.datenum = <int>recurringClassInstentVM.Id;
            //commonResponse.datenum.add(recurringClassInstentVM);
            return Ok(commonResponse);
        }
        public bool isCorrectDay(DateTime date, string day)
        {
            if ((date.DayOfWeek.ToString()) == day)
            {
                return true;
            }
            return false;
        }

        public List<ClassInstent> MakeClassList(RecurringClassContainer data, int week, String timeOfDay, String dayOfTheWeek)
        {
            List<ClassInstent> classlist = new List<ClassInstent>();
            DateTime firstDate = DateTime.Parse(data.FirstClassDate);
            DateTime WDtime = DateTime.Parse(timeOfDay);
            firstDate = firstDate.Add(WDtime.TimeOfDay);
            DateTime lastDate = DateTime.Parse(data.LastClassDate);
            DateTime endDate = firstDate.AddMinutes(Convert.ToDouble(data.Duration));
            bool rightDay =false;
            while (rightDay== false)
            {
                rightDay = isCorrectDay(firstDate, dayOfTheWeek);
                if (rightDay == false)
                {
                    firstDate = firstDate.AddDays(1);
                    endDate = endDate.AddDays(1);
                }
            }
            int i = 1;
            int dayccheack = DateTime.Compare(firstDate, lastDate);
            while (dayccheack  != 1 )
                {
                endDate = DateTime.Parse(data.FirstClassDate).AddMinutes(Convert.ToDouble(data.Duration));
                ClassInstent newClass = new ClassInstent()
                {
                    Title = data.Title + " Class " + i.ToString(),
                    Description = data.Description,
                    StartDate = firstDate,
                    EndDate = endDate,
                    Duration = data.Duration,
                    InstructerId = data.InstructerId,
                }; 


                classlist.Add(newClass);
                Console.WriteLine(firstDate);
                    firstDate = firstDate.AddDays(week);
                    i++;
                dayccheack = DateTime.Compare(firstDate, lastDate);
            }

            return classlist;
        }

        [HttpGet]
        [Route("GetRecurringClassesCalendarData")]
        public IActionResult GetRecurringClassesCalendarData(int recurringClassId)
        {
            CommonResponse<List<ClassVM>> commonResponse = new CommonResponse<List<ClassVM>>();
            try
            {
                //commonResponse.datenum = _classService.StudentEventsById(instructureId);
                commonResponse.datenum = _classService.StudentEventsByRecurringClassId(recurringClassId);
                commonResponse.status = Helper.success_code;
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }
            return Ok(commonResponse);
        }

        [HttpPost]
        [Route("EnrollStudent")]
        public IActionResult EnrollStudent(ClassStudentList data)
        {

            ClassStudentList classStudentList = new ClassStudentList();

            classStudentList.id = data.id;
            classStudentList.studentId = data.studentId;
            classStudentList.recurringClassInstentId = data.recurringClassInstentId;



            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _RecurringClassService.EnroleStudent(classStudentList).Result;
                if (commonResponse.status == 1)
                {
                    commonResponse.message = Helper.classUpdated;
                }
                if (commonResponse.status == 2)
                {
                    commonResponse.message = Helper.classAdded;
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }
            return Ok(commonResponse);
        }
        [HttpPost]
        [Route("addComment")]
        public IActionResult addComment(ClassStudentComment data)
        {
            ClassStudentComment classStudentComment = new ClassStudentComment();

            classStudentComment.ClassStudentListid = data.ClassStudentListid;
            classStudentComment.CommentDate = data.CommentDate;
            classStudentComment.Text = data.Text;



            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _RecurringClassService.AddComment(classStudentComment).Result;
                if (commonResponse.status == 1)
                {
                    commonResponse.message = Helper.classUpdated;
                }
                if (commonResponse.status == 2)
                {
                    commonResponse.message = Helper.classAdded;
                }
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }
            return Ok(commonResponse);
        }
    }

}
