using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExercise.Models
{
    public class AppendA
    {
        public string Appended { get; set; }

        public AppendA(string appendable)
        {
            Appended = appendable + "a";
        }
    }
}
