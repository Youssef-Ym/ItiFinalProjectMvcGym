using ItiFinalProjectMvcGym.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ItiFinalProjectMvcGym.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);


            if (model.Email.ToLower() == "admin@gym.com" && model.Password == "Admin123")
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                HttpContext.Session.SetString("UserEmail", model.Email);
                return RedirectToAction("Index", "GymClass");
            }
            else
            {
             
                HttpContext.Session.SetString("IsAdmin", "false");
                HttpContext.Session.SetString("UserEmail", model.Email);
                return RedirectToAction("Index", "GymClass");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}