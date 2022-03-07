using Semester_Project_0._1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Services
{
    public interface InterfaceRecurringClassService
    {
        public Task<int> AddUpdate(RecurringClassInstentVM model);
    }
}
