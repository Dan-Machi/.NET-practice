using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExercise.Models
{
    public class Number
    {
        public int Received { get; set; }
        public int Result { get; set; }
        public string Error { get; set; }
        public Number(int input)
        {
            Received = input;
            Result = 2 * input;
        }
    }
}
