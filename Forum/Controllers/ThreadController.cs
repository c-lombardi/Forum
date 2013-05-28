using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ThreadController : Controller
    {
        private ThreadDBContext db = new ThreadDBContext();

        public ActionResult ViewThreadDetail(int id)
        {
            var thread = new Forum.Models.Thread() { ThreadId = id, ThreadTitle = "This is the title", Posts = new List<Post>() };

            var newPost = new Post() { PostTitle = "", PostText = "", ThreadId = id };

            return View(new ThreadDetailViewModel() { Thread = thread, NewPost = newPost });
        }
    }

}
