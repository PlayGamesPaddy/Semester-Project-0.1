using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Semester_Project_0._1.Data;
using Semester_Project_0._1.Models;
using Semester_Project_0._1.Models.ViewModels;
using Semester_Project_0._1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semester_Project_0._1.Services
{
    public class RecurringClassService : InterfaceRecurringClassService
    {
        private readonly ApplicationDBContext _db;
        private readonly IEmailSender _emailSender;
        public RecurringClassService(ApplicationDBContext db, IEmailSender emailSender)
        {
            _db = db;
            _emailSender = emailSender;
        }

        public async Task<int> AddUpdate(RecurringClassInstentVM model)
        {
            var firstDate = DateTime.Parse(model.FirstClassDate);
            var lastDate = DateTime.Parse(model.LastClassDate);
            if (true)
            {

            }
            else
            {

            }
            var Instructer = _db.Users.FirstOrDefault(u => u.Id == model.InstructerId);
            RecurringClassInstent recurringClass = new RecurringClassInstent()
            {
                Title = model.Title,
                FirstClassDate = firstDate,
                LastClassDate = lastDate,
                Description = model.Description,
                Duration = model.Duration,
                InstructerId = model.InstructerId,
                Instructer = model.Instructer,
                RecurringType = model.RecurringType,
                Classlist = model.Classlist
            };
            //weekly
            //multibleDaysAWeek
            //everySecondWeek
            //onceAMounth
            List<ClassInstent>  classlist;
            //firstDate = firstDate.Add(model.weeklytimepicer);
            
            _db.RecurringClasses.Add(recurringClass);
            await _db.SaveChangesAsync();

            return 2;
        }
    }
}
