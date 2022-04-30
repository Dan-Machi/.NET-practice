using BasicWebshop.Models;
using BasicWebshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebshop.Controllers
{
    public class Shop : Controller
    {
        protected static List<Item> items;
        static Storage storage;
        static Shop()
        {
            items = new List<Item>()
            {
                new Item("abc", "sanikesdhjasjh", 100, 5),
                new Item("bcd", "dsfsbfdsgdsfs", 1000, 5),
                new Item("cde", "fdgdsfgdfgdfsgdfgsdfdgs", 300, 0),
                new Item("nike", "gfjhfghnfhjzftjhfgfj", 700, 5),
                new Item("efg", "rtrezzturzuut", 500, 5),
            };
            storage = new Storage();
            storage.StoredItems = items;
            storage.Average = 0;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View(storage);
        }

        [HttpGet("home")]
        public IActionResult MainPage()
        {
            storage.StoredItems = items;
            return RedirectToAction("Index");
        }

        [HttpGet("available")]
        public IActionResult OnlyAvailable()
        {
            storage.StoredItems = items.Where(x => x.Quantity > 0).ToList();
            return RedirectToAction("Index");
        }

        [HttpGet("cheapest")]
        public IActionResult CheapestFirst()
        {
            storage.StoredItems = items.OrderBy(x => x.Price).ToList();
            return RedirectToAction("Index");
        }

        [HttpGet("containsNike")]
        public IActionResult ContainsNike()
        {
            storage.StoredItems = items.Where(x => x.Name.ToLower().Contains("nike") || x.Desctription.ToLower().Contains("nike")).ToList();
            return RedirectToAction("Index");
        }

        [HttpGet("averageStock")]
        public IActionResult Average()
        {
            storage.Average = items.Average(x => x.Quantity);
            return View(storage);
        }

        [HttpGet("mostExpensive")]
        public IActionResult MostExpensive()
        {
            var maxPrice = items.OrderBy(x => x.Price).Last();
            List<Item> l = new List<Item> { maxPrice };
            storage.StoredItems = l;
            return RedirectToAction("Index");
        }

        [HttpPost("search")]
        public IActionResult Search(string name)
        {
            if (name != null)
            {
                storage.StoredItems = items.Where(x => x.Name.ToLower().Contains(name) || x.Desctription.ToLower().Contains(name)).ToList();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
