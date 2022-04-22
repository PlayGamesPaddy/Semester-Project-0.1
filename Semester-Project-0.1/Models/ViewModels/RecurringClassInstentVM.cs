using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semester_Project_0._1.Models.ViewModels
{
    public class RecurringClassInstentVM
    {
        public RecurringClassInstent recurringClassInstent { get; set; }
        [Key]
        public int? Id { get; set; }
        [DisplayName("Title")]
        [Required]
        public string Title { get; set; }
        [Required]
        [DisplayName("First Class Date")]
        public string FirstClassDate { get; set; }
        [Required]
        [DisplayName("Last Class Date")]
        public string LastClassDate { get; set; }
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Duration")]
        public int Duration { get; set; }
        [Required]
        [DisplayName("Instructer Id")]
        public string InstructerId { get; set; }
        [Required]
        [DisplayName("Instructer")]
        public ApplicationUser Instructer { set; get; }
        // StudentId temp will need to change to reference to student list
        [Required]
        [DisplayName("Class Size")]
        public int MaxNumberOfStudents { get; set; }
        public List<ClassStudentList> StudentList { get; set; }
        public List<ClassInstent> Classlist { set; get; }
        [DisplayName("Recurring Type")]
        public string RecurringType { get; set; }
        //public bool IsApproved { set; get; }
        //public string AdminId { get; set; }
    }
}
