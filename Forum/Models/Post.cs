using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Post
    {
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public int ThreadId { get; set; }
    }
}