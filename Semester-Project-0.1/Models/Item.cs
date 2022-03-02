using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Semester_Project_0._1.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Item Name")]
        [Required]
        public String Name { get; set; }
        [Required]
        public String Borrower { get; set; }
        [Required]
        //Eg for setting integer range
        //[Range(1, int.MaxValue, ErrorMessage ="Amount must be greather then 0 and not negitive!")]
        public String Lender { get; set; }

    }
}
