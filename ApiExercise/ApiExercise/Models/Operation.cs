using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExercise.Models
{
    public class Operation
    {
        public int Until { get; set; }
        public int Result { get; set; }
        public string Error { get; set; }
        public Operation()
        {
        }

        public void Operate(string s)
        {
            if (s == "sum")
            {
                for (int i = 0; i <= Until; i++)
                {
                    Result += i;
                } 
            }
            if (s == "factor")
            {
                Result = 1;
                for (int i = 1; i <= Until; i++)
                {
                    Result = Result * i;
                }
            }
        }

    }
}
