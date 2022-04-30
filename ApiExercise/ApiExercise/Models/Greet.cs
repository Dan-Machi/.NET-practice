using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExercise.Models
{
    public class Greet
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Error { get; set; }
        public string Welcome_message { get; set; }
        public Greet(string name, string title)
        {
            Name = name;
            Title = title;
            Welcome_message = $"Oh, hi there {Name}, my dear {Title}!";
        }
    }
}
