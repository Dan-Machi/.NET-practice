using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Models
{
    public class ViewPost
    {
        public List<Post> Posts { get; set; }
        public int Paging { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int Page { get; set; }
    }
}
