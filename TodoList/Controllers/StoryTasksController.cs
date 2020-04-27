using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoList.DataBase;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class StoryTasksController : Controller
    {
        private TodoListContext db = new TodoListContext();

        // GET: StoryTasks
        public ActionResult Index()
        {
            var storyTasks = db.StoryTasks.Include(s => s.Employee).Include(s => s.Story);
            return View(storyTasks.ToList());
        }

        // GET: StoryTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryTask storyTask = db.StoryTasks.Find(id);
            if (storyTask == null)
            {
                return HttpNotFound();
            }
            return View(storyTask);
        }

        // GET: StoryTasks/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.StoryId = new SelectList(db.Stories, "Id", "Title");
            return View();
        }

        // POST: StoryTasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Estimation,Title,Description,EmployeeId,StoryId")] StoryTask storyTask)
        {
            if (ModelState.IsValid)
            {
                db.StoryTasks.Add(storyTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", storyTask.EmployeeId);
            ViewBag.StoryId = new SelectList(db.Stories, "Id", "Title", storyTask.StoryId);
            return View(storyTask);
        }

        // GET: StoryTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryTask storyTask = db.StoryTasks.Find(id);
            if (storyTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", storyTask.EmployeeId);
            ViewBag.StoryId = new SelectList(db.Stories, "Id", "Title", storyTask.StoryId);
            return View(storyTask);
        }

        // POST: StoryTasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Estimation,Title,Description,EmployeeId,StoryId")] StoryTask storyTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storyTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", storyTask.EmployeeId);
            ViewBag.StoryId = new SelectList(db.Stories, "Id", "Title", storyTask.StoryId);
            return View(storyTask);
        }

        // GET: StoryTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryTask storyTask = db.StoryTasks.Find(id);
            if (storyTask == null)
            {
                return HttpNotFound();
            }
            return View(storyTask);
        }

        // POST: StoryTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoryTask storyTask = db.StoryTasks.Find(id);
            db.StoryTasks.Remove(storyTask);
            db.SaveChanges();
            return RedirectToAction("Index");
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
