using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public NoteController(ApplicationDbContext db)
        {
            dbContext = db;
        }

        // Action to view all Notes
        public IActionResult Index()
        {
            IEnumerable<Note> Notes = dbContext.Notes;
            return View(Notes);
        }

        // Action to Add New Notes - GET - What to do before user presses the submit button
        public IActionResult Add()
        {
            return View();
        }

        // Action to Add New Notes - POST - What the app does after the submit button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Note obj)
        {
            if (ModelState.IsValid)
            {
                dbContext.Notes.Add(obj);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // Action to Get Task Details
        public IActionResult Details(int? ID)
        {
            // Constraint to make ID greater than 0
            if (ID == null || ID == 0)
            {
                return NotFound();
            }

            // Find Notes by ID
            var task = dbContext.Notes.Find(ID);
            if (task is null)
            {
                return NotFound();
            }

            return View(task);
        }

        // Action to Get Task and Edit
        public IActionResult Edit(int? ID)
        {
            // Constraint to make ID greater than 0
            if (ID == null || ID == 0)
            {
                return NotFound();
            }

            // Find Notes by ID
            var task = dbContext.Notes.Find(ID);
            if (task is null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note obj)
        {
            if (ModelState.IsValid)
            {
                dbContext.Notes.Update(obj);
                dbContext.SaveChanges();
                return RedirectToAction("Details", new { id = obj.ID });
            }

            return View(obj);
        }

        // Action to GET Notes for Delete
        public IActionResult Delete(int? ID)
        {
            // Constraint to make ID greater than 0
            if (ID == null || ID == 0)
            {
                return NotFound();
            }

            // Find Notes by ID
            var task = dbContext.Notes.Find(ID);
            if (task is null)
            {
                return NotFound();
            }

            return View(task);
        }

        // Action to find Notes for Delete - POST
        public IActionResult DeleteNote(int? ID)
        {
            var obj = dbContext.Notes.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            dbContext.Notes.Remove(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}