using ApiExercise.Database;
using ApiExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExercise.Services
{
    public class LogService
    {
        private ApplicationDbContext DbContext { get; }
        public Log Log { get; set; }
        public LogService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Add(DateTime time, string endpoint, string data)
        {
            Log = new Log() { CreatedAt = time, Endpoint = endpoint, Data = data };
            DbContext.Logs.Add(Log);
            DbContext.SaveChanges();
        }

        public List<Log> FindAll()
        {
            return DbContext.Logs.ToList();
        }
    }
}
