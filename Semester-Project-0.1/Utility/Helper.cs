using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Utility
{
    /// <summary>
    ///  this is temp, i will move this to be managed by the database. also I whant t set it up so useres can have multible roles  
    /// </summary>
    public static class Helper
    {
        public const String SystemAdmin = "SystemAdmin";
        public const String Admin = "Admin";
        public const String Instructure = "Instructure";
        public const String User = "User";

        //public static string Admin = "Admin";
        //public static string Patient = "Patient";
        //public static string Doctor = "Doctor";

        //preset messages
        public static string classAdded = "Class added successfully.";
        public static string classUpdated = "Class updated successfully.";
        public static string classDeleted = "Class deleted successfully.";
        public static string classExists = "Class for selected date and time already exists.";
        public static string classNotExists = "Class does not exists.";
        public static string classConfirm = "Meeting confirm successfully";
        public static string classConfirmError = "Meeting confirm error";
        public static string classAddError = "Something went wront, Please try again.";
        public static string classUpdatError = "Something went wront, Please try again.";
        public static string somethingWentWrong = "Something went wront, Please try again.";
        public static int success_code = 1;
        public static int failure_code = 0;

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            if (isAdmin)
            {

                return new List<SelectListItem>
                {
                    new SelectListItem { Value = Helper.SystemAdmin.ToString(), Text = "SystemAdmin" },
                    new SelectListItem { Value = Helper.Admin.ToString(), Text = "Admin" },
                };
            }
            else
            {

                return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Instructure.ToString(),Text="Instructure"},
                    new SelectListItem{Value=Helper.User.ToString(),Text="User"}
                };
            }
        }
        public static List<SelectListItem> DaysOfTheWeek()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value="Monday",Text="Monday"},
                new SelectListItem{Value="Tuesday",Text="Tuesday"},
                new SelectListItem{Value="Wednesday",Text="Wednesday"},
                new SelectListItem{Value="Thursday",Text="Thursday"},
                new SelectListItem{Value="Friday",Text="Friday"},
                new SelectListItem{Value="Saturday",Text="Saturday"},
                new SelectListItem{Value="Sunday",Text="Sunday"}

            };
        }
        public static List<SelectListItem> WeekOfTheMonth()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value="1",Text="1st"},
                new SelectListItem{Value="2",Text="2nd"},
                new SelectListItem{Value="3",Text="3rd"},
                new SelectListItem{Value="4",Text="4rh"},
                new SelectListItem{Value="5",Text="last"},

            };
        }
        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> Duration = new List<SelectListItem>();
            for(int i = 1; i <= 12; i++)
            {
                Duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + "Hr" });
                minute = minute + 30;
                Duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + "Hr 30 Min" });
                minute = minute + 30;
            }
            return Duration;
        }
    }
}
