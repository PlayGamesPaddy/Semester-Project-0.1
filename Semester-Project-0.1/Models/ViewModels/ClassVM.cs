using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Models.ViewModels
{
    public class ClassVM
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string Description { get; set; }
        public string EndDate { get; set; }
        public int Duration { get; set; }
        public string InstructerId { get; set; }
        // StudentId temp will need to change to reference to student list
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        /// //////////////////////////////
        public bool IsApproved { set; get; }
        public string AdminId { get; set; }


        //names
        public string InstructureName { get; set; }
        public string AdminName { get; set; }
        public bool IsForClient { get; set; }

    }
}
