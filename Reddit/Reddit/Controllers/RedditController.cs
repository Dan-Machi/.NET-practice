using Microsoft.AspNetCore.Mvc;
using Reddit.Models;
using Reddit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Controllers
{
    [Route("")]
    public class RedditController : Controller
    {
        PostService PS { get; set; }
        UserService US { get; set; }
        int Page { get; set; }
        public RedditController(PostService postService, UserService userService)
        {
            PS = postService;
            US = userService;
            Page = 0;
        }
        public IActionResult Index()
        {
            ViewPost vp = new ViewPost();
            vp.Posts = PS.GetSortedByScore();
            vp.Paging = Page;
            return View(vp);
        }

        [HttpGet("new")]
        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult AddPost(string title, string text)
        {
            PS.AddPost(title, text, US.FindAll()[0]);
            return RedirectToAction("Index");
        }

        [HttpPost("likes")]
        public IActionResult Like(int like, int id)
        {
            PS.LikeDislike(like, id);
            return RedirectToAction("Index");
        }
        [HttpPost("page")]
        public IActionResult Paging(int page)
        {
            ViewPost vp = new ViewPost();
            vp.Posts = PS.GetSortedByScore();
            vp.Paging = PS.Page(page);
            return View("Index", vp);
        }
    }
}
