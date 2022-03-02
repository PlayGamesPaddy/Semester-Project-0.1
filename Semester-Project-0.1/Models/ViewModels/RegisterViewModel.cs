﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType (DataType.Password)]
        [StringLength(100, ErrorMessage="must be at reast 6 characters long", MinimumLength=6)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display (Name="Confirm Password")]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display (Name ="Role")]
        public String RoleId { get; set; }

        /*[Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }*/

    }
}
