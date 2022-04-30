using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExercise.Models
{
    public class Translate
    {
        public string Text { get; set; }
        public string Lang { get; set; }
        public string Translated { get; set; }
        public string Error { get; set; }
        public Translate()
        {
            Error = "I can't translate that!";
        }

        public void Translation()
        {
            Translated = Text;
            if (Lang == "en")
            {
                string s = "aioeuy";
                for (int i = 0; i < s.Length; i++)
                {
                    Translated = Translated.Replace(s[i].ToString(), $"v{s[i]}");
                } 
            }
        }
    }
}
