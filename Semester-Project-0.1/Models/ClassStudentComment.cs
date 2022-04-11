using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Models
{
    public class ClassStudentComment
    {
        public int? ClassStudentListid { get; set; }
        public ClassStudentList ClassStudentList { get; set; }
        public int Id { set; get; }
        public string commentatorId { set; get; }
        public ApplicationUser commentator { set; get; }
        public DateTime CommentDate { get; set; }
        public string Text { get; set; }
    }
}
