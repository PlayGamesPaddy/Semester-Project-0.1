using Semester_Project_0._1.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semester_Project_0._1.Models;

namespace Semester_Project_0._1.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ItemController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }
        //get-creath
        //reterns the view
        public IActionResult Create()
        {
            return View();
        }
        //post creath
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
