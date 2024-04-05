using Microsoft.AspNetCore.Mvc;
using System;

namespace BT2.Controllers
{
    public class Bai2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Success(string name)
        {
            ViewBag.Name = name;

            return View();
        }
        public IActionResult Receive(string username, string password, string email)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                return View("Index");
            }

            if (password.Length < 8 || !password.Any(char.IsDigit))
            {
                return View("Index");
            }

            if (!IsValidEmail(email))
            {
                return View("Index");
            }

            return RedirectToAction("Success", new { name = username });
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
