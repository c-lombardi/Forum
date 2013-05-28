using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/

        public ActionResult NewPost(Post newPost)
        {
            return PartialView(newPost);
        }

        public ActionResult Add(Post newPost)
        {
            return RedirectToAction("ViewThreadDetail", "Thread", new { id = newPost.ThreadId });
        }
    }
}
