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

    public class ThreadsController : Controller
    {
        private ForumDBContext db = new ForumDBContext();

        //
        // GET: /Threads/

        public ActionResult Index()
        {
            var viewmodel = new ThreadVM() { thread = new Thread(), threads = db.Threads.ToList()}; 
            return View(viewmodel);
        }

        //
        // GET: /Threads/Details/5

        public ActionResult Details(int threadid = 0, int postid = 0)
        {
            var viewmodel = new ThreadVM() { thread = new Thread(), threads = db.Threads.ToList()};
            return View(viewmodel);
        }

        //
        // GET: /Threads/Create

        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        //
        // POST: /Threads/Create

        [Authorize]
        [HttpPost]
        public ActionResult Create(Thread thread)
        {
            if (thread.ThreadTitle == null)
            {
                thread.ThreadTitle = "Empty";
            }
            if (ModelState.IsValid)
            {
                thread.TUserID = this.User.Identity.Name;    
                db.Threads.Add(thread);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thread);
        }

        //
        // GET: /Threads/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return View(thread);
        }

        //
        // POST: /Threads/Edit/5

        [HttpPost]
        public ActionResult Edit(Thread thread)
        {
            if (ModelState.IsValid)
            {
                thread.TUserID = this.User.Identity.Name;
                db.Entry(thread).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thread);
        }

        //
        // GET: /Threads/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Thread thread = db.Threads.Find(id);
            if (thread == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Threads/Delete/5
        [Authorize(Roles = "User, Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Thread thread = db.Threads.Find(id);
            db.Threads.Remove(thread);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}