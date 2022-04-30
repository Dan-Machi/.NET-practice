using FoxClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxClub.Services
{
    public class FoxService
    {
        public List<Fox> Foxes { get; set; }
        public List<string> Tricks { get; set; }
        public List<string> History { get; set; }
        public Fox LoggedFox;
        public FoxService()
        {
            Foxes = new List<Fox>();
            History = new List<string>();
            Foxes.Add(new Fox("Blue"));
            LoggedFox = Foxes[0];
            Tricks = new List<string>()
            {
                "C#", "Python", "Java", "C++", "JavaScript"
            };
        }

        public void AddFox(string name)
        {
            if (GetFox(name) == -1)
            {
                Foxes.Add(new Fox(name));
            }
        }

        public int GetFox(string name)
        {
            for (int i = 0; i < Foxes.Count; i++)
            {
                if (Foxes[i].Name == name)
                {
                    LoggedFox = Foxes[i];
                    return i;
                }
            }
            return -1;
        }
    }
}
