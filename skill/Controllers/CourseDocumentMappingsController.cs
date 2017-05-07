using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using skill.Models;

namespace skill.Controllers
{
    public class CourseDocumentMappingsController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CourseDocumentMappings
        public ActionResult Index()
        {
            return View(db.CourseDocMappings.ToList());
        }

        // GET: CourseDocumentMappings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDocMapping courseDocMapping = db.CourseDocMappings.Find(id);
            if (courseDocMapping == null)
            {
                return HttpNotFound();
            }
            return View(courseDocMapping);
        }

        // GET: CourseDocumentMappings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseDocumentMappings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseDocMappingId,CourseId,DocTitle,DocDetail,FIleName,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress")] CourseDocMapping courseDocMapping)
        {
            if (ModelState.IsValid)
            {
                db.CourseDocMappings.Add(courseDocMapping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseDocMapping);
        }

        // GET: CourseDocumentMappings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDocMapping courseDocMapping = db.CourseDocMappings.Find(id);
            if (courseDocMapping == null)
            {
                return HttpNotFound();
            }
            return View(courseDocMapping);
        }

        // POST: CourseDocumentMappings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseDocMappingId,CourseId,DocTitle,DocDetail,FIleName,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress")] CourseDocMapping courseDocMapping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseDocMapping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseDocMapping);
        }

        // GET: CourseDocumentMappings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDocMapping courseDocMapping = db.CourseDocMappings.Find(id);
            if (courseDocMapping == null)
            {
                return HttpNotFound();
            }
            return View(courseDocMapping);
        }

        // POST: CourseDocumentMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseDocMapping courseDocMapping = db.CourseDocMappings.Find(id);
            db.CourseDocMappings.Remove(courseDocMapping);
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
