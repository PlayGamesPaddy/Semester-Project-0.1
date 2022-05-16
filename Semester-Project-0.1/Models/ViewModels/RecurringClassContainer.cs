using Semester_Project_0._1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Models.ViewModels
{
    public class RecurringClassContainer
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int MaxNumberOfStudents { get; set; }
        [Required]
        public string FirstClassDate { get; set; }
        [Required]
        public string LastClassDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string InstructerId { get; set; }
        [Required]
        public string RecurringType { get; set; }

        public int Id { get; set; }


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
