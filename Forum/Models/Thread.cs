using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Thread
    {
        public int ThreadID { get; set; }
        public string ThreadTitle { get; set; }
        public class PostDBContext : DbContext
        {
            public DbSet<Post> Posts { get; set; }
        }
    }
}