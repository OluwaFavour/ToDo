using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            var task = new _Task() { Title = "Get Song", Details = "Yaba Buluku", Color = Color.RED };
            return View(task);
        }
    }
}
