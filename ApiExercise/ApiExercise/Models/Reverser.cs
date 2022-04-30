using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExercise.Models
{
    public class Reverser
    {
        public string Text { get; set; }
        public string Sith_Text { get; set; }
        public string Error { get; set; }
        public Reverser()
        {
            Error = "Feed me some text you have to, padawan young you are. Hmmm.";
        }

        public void YodaText()
        {
            string s = Text.Replace(".", " .");
            var arr = s.ToLower().Split(" ").ToArray();
            for (int i = 0; i < arr.Length - 1; i += 2)
            {
                if (!arr[i].Contains(".") && !arr[i + 1].Contains("."))
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]); 
                }
                else
                {
                    i--;
                }
            }
            arr[0] = string.Concat(arr[0][0].ToString().ToUpper(), arr[0].AsSpan(1));
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].Contains("."))
                {
                    arr[i] = string.Concat(arr[i][0].ToString().ToUpper(), arr[i].AsSpan(1));
                }
            }
            Sith_Text = String.Join(" ", arr).Replace(" .", ".");
        }
    }
}
