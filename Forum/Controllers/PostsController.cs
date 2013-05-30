using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Models;
using Forum.ViewModel;

namespace Forum.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class PostsController : Controller
    {
        private ForumDBContext db = new ForumDBContext();

        //
        // GET: /Posts/

        public ActionResult Index(int threadidd = 0)
        {
            
            Thread thread = db.Threads.Find(threadidd);
            if (threadidd != 0)
            {
                var viewmodel = new PostVM() { posts = db.Posts.ToList(), threadid = threadidd, thread = thread };
                return View(viewmodel);
            }
            return View();

        }

        //
        // GET: /Posts/Details/5

        public ActionResult Details(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // GET: /Posts/Create

        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        //
        // POST: /Posts/Create

        [HttpPost]
        public ActionResult Create(Post post, int threadid = 0)
        {
            if (post.PostTitle == null)
            {
                post.PostTitle = "Empty";
            }
            if (post.PostText == null)
            {
                post.PostText = "Empty";
            }
            if (ModelState.IsValid)
            {
                post.PUserID = this.User.Identity.Name; 
                post.ThreadID = threadid;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", new { threadidd = threadid });
            }

            return View(post);
        }

        //
        // GET: /Posts/Edit/5

        public ActionResult Edit(int id = 0, int threadid = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new PostEditVM() { post = post, threadid = threadid };
            return View(viewmodel);
        }

        //
        // POST: /Posts/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post, int threadid = 0)
        {
            if (ModelState.IsValid)
            {
                post.PUserID = this.User.Identity.Name; 
                post.ThreadID = threadid;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { threadidd = threadid });
            }
            return View(post);
        }

        //
        // GET: /Posts/Delete/5
    
        public ActionResult Delete(int id = 0)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Posts/Delete/5
        [Authorize(Roles = "User, Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, int threadid)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index", new { threadidd = threadid });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}