using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Milestone5.DAL;
using Milestone5.Models;
using Milestone5.ViewModels;

namespace Milestone5.Controllers
{
    public class PostsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Posts
        public ActionResult Index(int? id)
        {
            var viewModel = new PostsIndexData();
            viewModel.Posts = db.Posts
                .Include(p => p.Comments)
                .OrderByDescending(p => p.PublishDate);

            if (id != null)
            {
                ViewBag.PostID = id.Value;
                viewModel.Comments = viewModel.Posts
                    .Where(p => p.ID == id.Value)
                    .Single()
                    .Comments
                        .OrderByDescending(c => c.PublishDate);
            }
            ViewBag.Nav = "Manage";
            return View(viewModel);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nav = "Manage";
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.Nav = "Manage";
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,AuthorName,AuthorWebsite,Text,ImageUrl,VideoUrl")] Post post)
        {
            post.PublishDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nav = "Manage";
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,AuthorName,AuthorWebsite,PublishDate,Text,ImageUrl,VideoUrl")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nav = "Manage";
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nav = "Manage";
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Posts/DeleteComment/5
        public ActionResult DeleteComment(int? commentId)
        {
            if (commentId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var comment = db.Comments.Find(commentId);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nav = "Manage";
            return View(comment);
        }

        // POST: Posts/DeleteComment/5
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCommentConfirmed(int commentId)
        {
            var comment = db.Comments.Find(commentId);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = comment.PostID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
