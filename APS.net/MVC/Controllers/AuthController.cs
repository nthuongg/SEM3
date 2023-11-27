using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            List<UserRegisterModel> ls = new List<UserRegisterModel>();
            ls.Add(new UserRegisterModel
            {
                Id = 1,
                Email = "Nam@gmail.com",
                FullName = "Nguyen Van Nam",
                Telephone = "0123456789"
            });

            ls.Add(new UserRegisterModel
            {
                Id = 2,
                Email = "Duy@gmail.com",
                FullName = "Nguyen Van Duy",
                Telephone = "0987654321"
            });

            // ViewData["users"] = ls; cach 1
            // ViewBag.users = ls; cach 2
            return View(ls); //cach 3: truyen thang ls (chi dung khi ls la du lieu chinh)
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
