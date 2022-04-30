using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExercise.Models
{
    public class ArrHandl
    {
        public string What { get; set; }
        public int[] Numbers { get; set; }
        public int Result { get; set; }

        public string Error { get; set; }
        public ArrHandl()
        {
        }

        public void Handle()
        {
            if (What == null)
            {
                Error = "Please provide what to do with the numbers!";
            }
            if (What == "sum")
            {
                for (int i = 0; i < Numbers.Length; i++)
                {
                    Result += Numbers[i];
                }
            }
            if (What == "multiply")
            {
                Result = 1;
                for (int i = 0; i < Numbers.Length; i++)
                {
                    Result *= Numbers[i];
                }
            }
            //if (What == "double")
            //{
            //    for (int i = 0; i < Numbers.Length; i++)
            //    {

            //    }
            //}

        }
    }
}
