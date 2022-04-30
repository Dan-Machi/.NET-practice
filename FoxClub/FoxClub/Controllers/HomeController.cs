using FoxClub.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxClub.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        FoxService fs;
        public HomeController(FoxService foxService)
        {
            fs = foxService;
        }

        public IActionResult Index()
        {
            return View(fs);
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("addfox")]
        public IActionResult AddFox(string name)
        {
            fs.AddFox(name);
            fs.GetFox(name);
            fs.History.Add($"{DateTime.Now.ToString()} : Fox {name} was created.");
            return RedirectToAction("Index", new {fs.LoggedFox.Name});
        }

        [HttpGet("store")]
        public IActionResult Store()
        {
            return View();
        }

        [HttpPost("change")]
        public IActionResult Change(string food, string drink)
        {
            fs.LoggedFox.Food = food;
            fs.LoggedFox.Drink = drink;
            fs.History.Add($"{DateTime.Now.ToString()} : Food was changed to: {food}");
            fs.History.Add($"{DateTime.Now.ToString()} : Drink was changed to: {drink}");
            return RedirectToAction("Index");
        }

        [HttpGet("trick")]
        public IActionResult Trick()
        {
            return View(fs);
        }

        [HttpPost("learn")]
        public IActionResult Learn(string trick)
        {
            fs.LoggedFox.Tricks.Add(trick);
            fs.History.Add($"{DateTime.Now.ToString()} : Learned: {trick}");
            return RedirectToAction("Index");
        }

        [HttpGet("history")]
        public IActionResult History()
        {
            return View(fs);
        }
    }
}
