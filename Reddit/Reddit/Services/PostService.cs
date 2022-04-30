using Reddit.Database;
using Reddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Services
{
    public class PostService
    {
        private ApplicationDbContext DbContext { get; set; }
        public int Paging { get; set; }
        public PostService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            Paging = 0;
        }

        public List<Post> GetAll()
        {
            return DbContext.Posts.ToList();
        }
        public List<Post> GetSortedByScore()
        {
            List<Post> posts = DbContext.Posts.ToList();
            posts.Sort((x, y) => x.Score.CompareTo(y.Score));
            return posts;
        }

        public void AddPost(string title, string text, User user)
        {
            DbContext.Posts.Add(new Post(title, text, user));
            DbContext.SaveChanges();
        }

        public void LikeDislike(int like, int id)
        {
            GetAll().Where(x => x.Id == id).Select(x=>x.Score += like).FirstOrDefault();
            DbContext.SaveChanges();
        }

        public int Page(int page)
        {
            Paging += page * 5;
            if (Paging < 0)
            {
                return  0;
            }
            if (Paging > DbContext.Posts.Count() - 6)
            {
                return DbContext.Posts.Count() - 6;
            }
            return Paging;
        }
        //public int StartPage(int position, int page)
        //{

        //}
    }
}
