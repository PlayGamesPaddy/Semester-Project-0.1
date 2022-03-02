using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semester_Project_0._1.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [DisplayName("First Name")]
        [Required]
        public String StudentNameFirst { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public String StudentNameLast { get; set; }
        [DisplayName("Email")]
        [EmailAddress]
        public String StudentEmail { get; set; }
        [DisplayName("Type")]
        public int StudentTypeId { get; set; }
        [ForeignKey("StudentTypeId")]
        public virtual StudentType StudentType { get; set; }

        [ForeignKey("PrimaryGuardian")]
        public String PrimaryGuardian { get; set; }
    }
}
