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
    public class CourseRegistrationDetailsController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CourseRegistrationDetails
        public ActionResult Index()
        {
            return View(db.CourseRegistrationDetails.ToList());
        }

        // GET: CourseRegistrationDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistrationDetail courseRegistrationDetail = db.CourseRegistrationDetails.Find(id);
            if (courseRegistrationDetail == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistrationDetail);
        }

        // GET: CourseRegistrationDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseRegistrationDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseRegistrationDetailId,CourseId,RegistrationId,Mode,PaymentStatus,TotalPaymentAmount,PendingPaymentAmount,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CourseRegistrationDetail courseRegistrationDetail)
        {
            if (ModelState.IsValid)
            {
                db.CourseRegistrationDetails.Add(courseRegistrationDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseRegistrationDetail);
        }

        // GET: CourseRegistrationDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistrationDetail courseRegistrationDetail = db.CourseRegistrationDetails.Find(id);
            if (courseRegistrationDetail == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistrationDetail);
        }

        // POST: CourseRegistrationDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseRegistrationDetailId,CourseId,RegistrationId,Mode,PaymentStatus,TotalPaymentAmount,PendingPaymentAmount,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CourseRegistrationDetail courseRegistrationDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseRegistrationDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseRegistrationDetail);
        }

        // GET: CourseRegistrationDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistrationDetail courseRegistrationDetail = db.CourseRegistrationDetails.Find(id);
            if (courseRegistrationDetail == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistrationDetail);
        }

        // POST: CourseRegistrationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseRegistrationDetail courseRegistrationDetail = db.CourseRegistrationDetails.Find(id);
            db.CourseRegistrationDetails.Remove(courseRegistrationDetail);
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
