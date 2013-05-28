using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
    }

}