using Reddit.Database;
using Reddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Services
{
    public class UserService
    {
        ApplicationDbContext DbContext { get; set; }
        public UserService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<User> FindAll()
        {
            return DbContext.Users.ToList();
        }
    }
}
