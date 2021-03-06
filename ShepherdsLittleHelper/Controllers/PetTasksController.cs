﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShepherdsLittleHelper.Models;

namespace ShepherdsLittleHelper.Controllers
{
    public class PetTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PetTasks
        public ActionResult Index()
        {
            var petTasks = db.PetTasks.Include(p => p.ApplicationUser).Include(p => p.Location).Include(p => p.Pet).Include(p => p.TaskType);
            return View(petTasks.ToList());
        }

        // GET: PetTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetTask petTask = db.PetTasks.Find(id);
            if (petTask == null)
            {
                return HttpNotFound();
            }
            return View(petTask);
        }

        // GET: PetTasks/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserID = new SelectList(db.ApplicationUsers, "Id", "Email");
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName");
            ViewBag.PetID = new SelectList(db.Pets, "PetID", "PetName");
            ViewBag.TaskTypeID = new SelectList(db.TaskTypes, "TaskID", "TaskTypeName");
            return View();
        }

        // POST: PetTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskID,TaskDescription,Frequency,Deadline,LocationID,PetID,TaskTypeID,ApplicationUserID")] PetTask petTask)
        {
            if (ModelState.IsValid)
            {
                db.PetTasks.Add(petTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserID = new SelectList(db.ApplicationUsers, "Id", "Email", petTask.ApplicationUserID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", petTask.LocationID);
            ViewBag.PetID = new SelectList(db.Pets, "PetID", "PetName", petTask.PetID);
            ViewBag.TaskTypeID = new SelectList(db.TaskTypes, "TaskID", "TaskTypeName", petTask.TaskTypeID);
            return View(petTask);
        }

        // GET: PetTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetTask petTask = db.PetTasks.Find(id);
            if (petTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserID = new SelectList(db.ApplicationUsers, "Id", "Email", petTask.ApplicationUserID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", petTask.LocationID);
            ViewBag.PetID = new SelectList(db.Pets, "PetID", "PetName", petTask.PetID);
            ViewBag.TaskTypeID = new SelectList(db.TaskTypes, "TaskID", "TaskTypeName", petTask.TaskTypeID);
            return View(petTask);
        }

        // POST: PetTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskID,TaskDescription,Frequency,Deadline,LocationID,PetID,TaskTypeID,ApplicationUserID")] PetTask petTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserID = new SelectList(db.ApplicationUsers, "Id", "Email", petTask.ApplicationUserID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", petTask.LocationID);
            ViewBag.PetID = new SelectList(db.Pets, "PetID", "PetName", petTask.PetID);
            ViewBag.TaskTypeID = new SelectList(db.TaskTypes, "TaskID", "TaskTypeName", petTask.TaskTypeID);
            return View(petTask);
        }

        // GET: PetTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetTask petTask = db.PetTasks.Find(id);
            if (petTask == null)
            {
                return HttpNotFound();
            }
            return View(petTask);
        }

        // POST: PetTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PetTask petTask = db.PetTasks.Find(id);
            db.PetTasks.Remove(petTask);
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
