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
    [Route("api/Class")]
    [ApiController]
    public class ClassApiController : Controller
    {
        private readonly IClassService _classService;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;
        public ClassApiController(IClassService classService, IHttpContextAccessor httpContextAccessor)
        {
            _classService = classService;
            _HttpContextAccessor = httpContextAccessor;
            loginUserId = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        }
        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(ClassVM data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try {
                commonResponse.status = _classService.AddUpdate(data).Result;
                if (commonResponse.status == 1)
                {
                    commonResponse.message = Helper.classUpdated;
                }
                if (commonResponse.status == 2)
                {
                    commonResponse.message = Helper.classAdded;
                }
            }
            catch(Exception e) {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }
            return Ok(commonResponse);
        }

        [HttpGet]
        [Route("GetCalendarData")]
        public IActionResult GetCalendarData(string instructureId)
        {
            CommonResponse<List<ClassVM>> commonResponse = new CommonResponse<List<ClassVM>>();
            try
            {
                if (role == Helper.User)
                {
                    //commonResponse.datenum = _classService.StudentEventsById(loginUserId);
                    commonResponse.datenum = _classService.InstructureEventsById(loginUserId);
                    commonResponse.status = Helper.success_code;
                }
                else if(role == Helper.Instructure)
                {
                    //commonResponse.datenum = _classService.StudentEventsById(loginUserId);
                    commonResponse.datenum = _classService.InstructureEventsById(loginUserId);
                    commonResponse.status = Helper.success_code;
                }
                else
                {
                    //commonResponse.datenum = _classService.StudentEventsById(instructureId);
                    commonResponse.datenum = _classService.InstructureEventsById(instructureId);
                    commonResponse.status = Helper.success_code;
                }
            }
            catch(Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }
            return Ok(commonResponse);
        }





        [HttpGet]
        [Route("GetCalendarDataById/{id}")]
        public IActionResult GetCalendarDataById(int id)
        {
            CommonResponse<ClassVM> commonResponse = new CommonResponse<ClassVM>();
            try
            {
                                
                    commonResponse.datenum = _classService.GetById(id);
                    commonResponse.status = Helper.success_code;
                
            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }
            return Ok(commonResponse);
        }


        [HttpGet]
        [Route("DeleteClass/{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {

                commonResponse.status = await _classService.Delete(id);
                commonResponse.message = commonResponse.status == 1 ? Helper.classDeleted : Helper.somethingWentWrong;

            }
            catch (Exception e)
            {
                commonResponse.message = e.Message;
                commonResponse.status = Helper.failure_code;
            }
            return Ok(commonResponse);
        }


        [HttpGet]
        [Route("ConfirmEvent/{id}")]
        public async Task<IActionResult> ConfirmEvent(int id)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                var result = _classService.ConfirmEvent(id).Result;
                if (result > 0)
                {

                    commonResponse.status = Helper.success_code;
                    commonResponse.message = Helper.classConfirm;
                }
                else
                {

                    commonResponse.status = Helper.failure_code;
                    commonResponse.message = Helper.classConfirmError;
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
