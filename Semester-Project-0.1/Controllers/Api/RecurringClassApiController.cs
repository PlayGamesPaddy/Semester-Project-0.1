using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly InterfaceRecurringClassService _RecurringClassService;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;
        public RecurringClassApiController(InterfaceRecurringClassService recurringClassService, IHttpContextAccessor httpContextAccessor)
        {
            _RecurringClassService = recurringClassService;
            _HttpContextAccessor = httpContextAccessor;
            loginUserId = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        }

        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(RecurringClassInstentVM data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status = _RecurringClassService.AddUpdate(data).Result;
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
