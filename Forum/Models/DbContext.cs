using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ForumDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }
    }
}