using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RascalChat.Models
{
    public class ViewUser
    {
        public string Error { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public string AvatarUrl { get; set; }
        public string ApiKey { get; set; }

    }
}
