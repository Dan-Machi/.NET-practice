﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Post(string title, string text, User user)
        {
            Score = 0;
            Title = title;
            Text = text;
            User = user;
        }

        public Post()
        {

        }
    }
}
