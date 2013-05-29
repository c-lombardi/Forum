using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.ViewModel
{
    public class PostEditVM
    {
        public int threadid { get; set; }
        public Post post { get; set; }
    }
}