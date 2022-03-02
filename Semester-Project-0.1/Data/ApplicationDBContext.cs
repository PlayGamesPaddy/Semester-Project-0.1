using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Semester_Project_0._1.Models;

namespace Semester_Project_0._1.Data
{
    public class ApplicationDBContext: IdentityDbContext<ApplicationUser>
        {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentType> StudentTypes { get;  set; }
        public DbSet<ClassInstent> Classes { get; set; }
    }
}
