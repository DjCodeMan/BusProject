using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusProject.Models;

namespace BusProject.Controllers
{
    public class TheStudentsController : Controller
    {
        private thebusEntities db = new thebusEntities();

        // GET: TheStudents
        public ActionResult Index()
        {
            var thestudents = db.thestudents.Include(t => t.Bus).Include(t => t.time);
            return View(thestudents.ToList());
        }

        // GET: TheStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thestudent thestudent = db.thestudents.Find(id);
            if (thestudent == null)
            {
                return HttpNotFound();
            }
            return View(thestudent);
        }

        // GET: TheStudents/Create
        public ActionResult Create()
        {
            ViewBag.Desired_bus = new SelectList(db.Buses, "id", "Bus1");
            ViewBag.Desired_time = new SelectList(db.times, "id", "id");
            return View();
        }

        // POST: TheStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Student_number,Name,Surname,Campus,Department,Desired_bus,Desired_time")] thestudent thestudent)
        {
            if (ModelState.IsValid)
            {
                db.thestudents.Add(thestudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Desired_bus = new SelectList(db.Buses, "id", "Bus1", thestudent.Desired_bus);
            ViewBag.Desired_time = new SelectList(db.times, "id", "id", thestudent.Desired_time);
            return View(thestudent);
        }

        // GET: TheStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thestudent thestudent = db.thestudents.Find(id);
            if (thestudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.Desired_bus = new SelectList(db.Buses, "id", "Bus1", thestudent.Desired_bus);
            ViewBag.Desired_time = new SelectList(db.times, "id", "id", thestudent.Desired_time);
            return View(thestudent);
        }

        // POST: TheStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Student_number,Name,Surname,Campus,Department,Desired_bus,Desired_time")] thestudent thestudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thestudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Desired_bus = new SelectList(db.Buses, "id", "Bus1", thestudent.Desired_bus);
            ViewBag.Desired_time = new SelectList(db.times, "id", "id", thestudent.Desired_time);
            return View(thestudent);
        }

        // GET: TheStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thestudent thestudent = db.thestudents.Find(id);
            if (thestudent == null)
            {
                return HttpNotFound();
            }
            return View(thestudent);
        }

        // POST: TheStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thestudent thestudent = db.thestudents.Find(id);
            db.thestudents.Remove(thestudent);
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
