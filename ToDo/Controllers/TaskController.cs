using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TaskController(ApplicationDbContext db)
        {
            dbContext = db;
        }

        // Action to view all tasks
        public IActionResult Index()
        {
            IEnumerable<_Task> tasks = dbContext.Tasks;
            return View(tasks);
        }

        // Action to Add New Tasks - GET - What to do before user presses the submit button
        public IActionResult Add()
        {
            return View();
        }

        // Action to Add New Tasks - POST - What the app does after the submit button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(_Task obj)
        {
            dbContext.Tasks.Add(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
