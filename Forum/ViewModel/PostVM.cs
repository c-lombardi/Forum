using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.ViewModel
{
    public class PostVM
    {
        public Post post { get; set; }
        public IEnumerable<Post> posts { get; set; }
    }
}