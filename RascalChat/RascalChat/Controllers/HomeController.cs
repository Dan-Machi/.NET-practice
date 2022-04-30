using Microsoft.AspNetCore.Mvc;
using RascalChat.Models;
using RascalChat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RascalChat.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        UserService UserService { get; set; }
        public HomeController(UserService userService)
        {
            UserService = userService;
        }
        public IActionResult Index()
        {
            ViewUser vu = new ViewUser();
            return View(vu);
        }

        [HttpGet("registration")]
        public IActionResult Register()
        {
            ViewUser vu = new ViewUser();
            return View(vu);
        }

        [HttpPost("register")]
        public IActionResult Add(string login, string password)
        {
            User user = UserService.Register(login, password);
            if (user != null)
            {
                return RedirectToAction();
            }
            else
            {
                ViewUser vu = new ViewUser();
                vu.Error = "Username is taken";
                return View("Register", vu);
            }
        }

        [HttpGet("loginpage")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(string login, string password)
        {
            Key key = UserService.Login(login, password);
            if (key != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewUser vu = new ViewUser();
                vu.Error = "Wrong username or password";
                return View("LoginPage", vu);
            }
        }

        [HttpGet("info")]
        public IActionResult Info()
        {
            User user = UserService.Info();
            ViewUser vu = new ViewUser();
            vu.Username = user.Username;
            vu.UserId = user.UserId;
            vu.AvatarUrl = user.AvatarUrl;
            return View(vu);

        }
    }
}
