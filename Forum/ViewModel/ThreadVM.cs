using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.ViewModel
{
    public class ThreadVM
    {
        public Thread thread { get; set; }
        public int ID { get; set; }
        public IEnumerable<Thread> threads { get; set; }
        public string TUserID { get; set; }
        //public Post post { get; set; }
        //public IEnumerable<Post> posts { get; set; }
    }
}