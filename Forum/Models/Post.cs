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
        public  int SortID { get; set; }
        public string PUserID {get; set;}

        public int ThreadID { get; set; }
        public virtual Thread Thread { get; set; }
    }

}