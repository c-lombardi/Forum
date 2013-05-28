using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ThreadDetailViewModel
    {
        public Thread Thread { get; set; }
        public Post NewPost { get; set; }
    }
}