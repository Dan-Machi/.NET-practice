using BankOfSimba.Models;
using BankOfSimba.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfSimba.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        protected static List<BankAccount> bank;
        static HomeController()
        {
            bank = new List<BankAccount>();
            bank.Add(new BankAccount("Simba", 2000, "lion"));
            bank[0].IsKing = true;
            bank.Add(new BankAccount("Scar", 5, "lion"));
            bank[1].IsBad = true;
            bank.Add(new BankAccount("Pumba", 50, "pig"));
            bank.Add(new BankAccount("Timon", 20, "rat"));
            bank.Add(new BankAccount("Zazu", 900, "bird"));
        }
        [Route("show")]
        public IActionResult Index()
        {
            BankAccount lionBC = new BankAccount("Simba", 2000, "lion");
            return View(lionBC);
        }

        [HttpGet("table")]
        public IActionResult AccList()
        {
            AccList acc = new AccList();
            acc.BankAccs = bank;
            return View(acc);
        }

        [HttpPost("table/add")]
        public ActionResult Deposit(int deposit)
        {
            if (bank[deposit].IsKing) bank[deposit].Balance += 100; else bank[deposit].Balance += 10;
            return RedirectToAction("AccList");
        }

        [HttpPost("table/newacc")]
        public ActionResult NewAccount(string name, int balance, string animalType, string isBad)
        {
            bank.Add(new BankAccount(name, balance, animalType));
            if (isBad == "yes") { bank[bank.Count - 1].IsBad = true; }
            return RedirectToAction("AccList");
        }
    }
}
