using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Thread
    {
        public int ThreadId { get; set; }
        public string ThreadTitle { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class ThreadDBContext : DbContext
    {
        public DbSet<Thread> Threads { get; set; }
    }
}