﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheZeusSystem.Models;

namespace TheZeusSystem.Controllers
{
    [Authorize]
    public class EmplyeeInfoesController : Controller
    {
        private TZSdb db = new TZSdb();

        [AllowAnonymous]
        // GET: EmplyeeInfoes
        public ActionResult Index()
        {
            return View(db.EmplyeeInfoes.ToList());
        }

        // GET: EmplyeeInfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmplyeeInfo emplyeeInfo = db.EmplyeeInfoes.Find(id);
            if (emplyeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(emplyeeInfo);
        }

        // GET: EmplyeeInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmplyeeInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeName,EmployeeAddress,EmployeePhoneNumber,EmployeeEmailID,EmployeeDoB")] EmplyeeInfo emplyeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmplyeeInfoes.Add(emplyeeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emplyeeInfo);
        }

        // GET: EmplyeeInfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmplyeeInfo emplyeeInfo = db.EmplyeeInfoes.Find(id);
            if (emplyeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(emplyeeInfo);
        }

        // POST: EmplyeeInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,EmployeeName,EmployeeAddress,EmployeePhoneNumber,EmployeeEmailID,EmployeeDoB")] EmplyeeInfo emplyeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emplyeeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emplyeeInfo);
        }

        // GET: EmplyeeInfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmplyeeInfo emplyeeInfo = db.EmplyeeInfoes.Find(id);
            if (emplyeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(emplyeeInfo);
        }

        // POST: EmplyeeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmplyeeInfo emplyeeInfo = db.EmplyeeInfoes.Find(id);
            db.EmplyeeInfoes.Remove(emplyeeInfo);
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
