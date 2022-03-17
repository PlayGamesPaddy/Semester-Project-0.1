using Semester_Project_0._1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Utility
{
    public class RecurringClassContainer
    {
        public string Title { get; set; }
        public int MaxNumberOfStudents { get; set; }
        public string FirstClassDate { get; set; }
        public string LastClassDate { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string InstructerId { get; set; }
        public string RecurringType { get; set; }




        public string weeklyday { get; set; }
        public string weeklytimepicer { get; set; }

        public bool cbMonday { get; set; }
        public string montimepicker { get; set; }
        public bool cbTuesday { get; set; }
        public string tuetimepicker { get; set; }
        public bool cbWednesday { get; set; }
        public string wentimepicker { get; set; }
        public bool cbThursday { get; set; }
        public string thutimepicker { get; set; }
        public bool cbFriday { get; set; }
        public string fritimepicker { get; set; }
        public bool cbSaturday { get; set; }
        public string sattimepicker { get; set; }
        public bool cbSunday { get; set; }
        public string suntimepicker { get; set; }

        public string secondweekdaysoftheweekradio { get; set; }
        public string secondweeklytimepicer { get; set; }

        public string onceaMonthradio { get; set; }
        public string mounthtimepicer { get; set; }
    }
}
