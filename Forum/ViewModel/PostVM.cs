using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.ViewModel
{
    public class PostVM
    {
        public Thread thread { get; set; }
        public int threadid { get; set; }
        public Post post { get; set; }
        public IEnumerable<Post> posts { get; set; }
        public string PUserID { get; set; }
    }
}