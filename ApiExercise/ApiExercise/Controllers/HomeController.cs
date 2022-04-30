using ApiExercise.Models;
using ApiExercise.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExercise.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        LogService LS { get; set; }
        public HomeController(LogService logService)
        {
            LS = logService;
        }
        public IActionResult Index()
        {
            return File("index.html", "text/html");
        }
    
        [HttpGet("doubling")]
        public Number Double([FromQuery] int input)
        {
            LS.Add(DateTime.Now, "doubling", input.ToString());
            if (input == 0)
            {
                return new Number(input) { Error = "Please provide an input!" };
            }
            Number num = new Number(input);
            return num;
        }

        [HttpGet("greeter")]
        public ObjectResult Greeter([FromQuery] string name, string title)
        {
            LS.Add(DateTime.Now, "greeter", $"{name} {title}");
            if (name == null && title == null)
            {
                return StatusCode(400, new Greet(name, title) { Error = "Please provide a name and a title!" });
            }
            else if (name == null)
            {
                return StatusCode(400, new Greet(name, title) { Error = "Please provide a name!" });
            }
            else if (title == null)
            {
                return StatusCode(400, new Greet(name, title) { Error = "Please provide a title!" });
            }
            Greet greet = new Greet(name, title);
            return StatusCode(200, greet);
        }

        [HttpGet("appenda/{appendable}")]
        public AppendA Append(string appendable)
        {
            LS.Add(DateTime.Now, "appenda", appendable);
            AppendA app = new AppendA(appendable);
            return app;
        }

        [HttpPost("dountil/{operation}")]
        public IActionResult Opera(string operation, [FromBody] Operation op)
        {
            LS.Add(DateTime.Now, "dountil", operation);
            op.Operate(operation);
            return Ok(op);
        }

        [HttpPost("arrays")]
        public IActionResult Arr([FromBody] ArrHandl ah)
        {
            ah.Handle();
            return Ok(ah);
        }

        [HttpGet("log")]
        public IActionResult Log()
        {
            return Ok(LS.FindAll());
        }

        [HttpPost("sith")]
        public IActionResult Sith([FromBody] Reverser reverser)
        {
            reverser.YodaText();
            return Ok(reverser);
        }

        [HttpPost("translate")]
        public IActionResult Translate([FromBody] Translate translate)
        {
            translate.Translation();
            return Ok(translate);
        }
    }

}
