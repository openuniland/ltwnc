using Microsoft.AspNetCore.Mvc;
using System;

namespace BT1.Controllers
{
    public class Bai1Controller : Controller
    {
        public IActionResult Index()
        {
            var currentTime = DateTime.Now;

            ViewBag.CurrentTime = currentTime;

            return View();
        }

        public IActionResult Welcome(string name)
        {
            var greeting = "Xin chào " + name;
            ViewBag.Greeting = greeting;

            return View();
        }
    }
}
