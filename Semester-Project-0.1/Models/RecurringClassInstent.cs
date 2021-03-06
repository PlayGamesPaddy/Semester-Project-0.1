using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semester_Project_0._1.Models
{
    public class RecurringClassInstent
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("First Class Date")]
        public DateTime FirstClassDate { get; set; }
        [DisplayName("Last Class Date")]
        public DateTime LastClassDate { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Duration")]
        public int Duration { get; set; }
        [DisplayName("Instructer Id")]
        public string InstructerId { get; set; }
        [DisplayName("Instructer")]
        public ApplicationUser Instructer { set; get; }
        // StudentId temp will need to change to reference to student list
        [DisplayName("Class Size")]
        public int MaxNumberOfStudents { get; set; }
        //[DisplayName("Students Enrolled")]
        //[DefaultValue(0)]
        //public int StudentsEnrolled { get; set; }
        public List<ClassStudentList> StudentList { get; set; }
        public List<ClassInstent> Classlist { set; get; }
        [DisplayName("Recurring Type")]
        public string RecurringType { get; set; }
        //public bool IsApproved { set; get; }
        //public string AdminId { get; set; }

    }
}
