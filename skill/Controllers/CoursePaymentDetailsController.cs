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
    public class CoursePaymentDetailsController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CoursePaymentDetails
        public ActionResult Index()
        {
            return View(db.CoursePaymentDetails.ToList());
        }

        // GET: CoursePaymentDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursePaymentDetail coursePaymentDetail = db.CoursePaymentDetails.Find(id);
            if (coursePaymentDetail == null)
            {
                return HttpNotFound();
            }
            return View(coursePaymentDetail);
        }

        // GET: CoursePaymentDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoursePaymentDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,RegistrationId,PaymentMode,PaymentDate,PaymentAmount,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CoursePaymentDetail coursePaymentDetail)
        {
            if (ModelState.IsValid)
            {
                db.CoursePaymentDetails.Add(coursePaymentDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coursePaymentDetail);
        }

        // GET: CoursePaymentDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursePaymentDetail coursePaymentDetail = db.CoursePaymentDetails.Find(id);
            if (coursePaymentDetail == null)
            {
                return HttpNotFound();
            }
            return View(coursePaymentDetail);
        }

        // POST: CoursePaymentDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,RegistrationId,PaymentMode,PaymentDate,PaymentAmount,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CoursePaymentDetail coursePaymentDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursePaymentDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coursePaymentDetail);
        }

        // GET: CoursePaymentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursePaymentDetail coursePaymentDetail = db.CoursePaymentDetails.Find(id);
            if (coursePaymentDetail == null)
            {
                return HttpNotFound();
            }
            return View(coursePaymentDetail);
        }

        // POST: CoursePaymentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoursePaymentDetail coursePaymentDetail = db.CoursePaymentDetails.Find(id);
            db.CoursePaymentDetails.Remove(coursePaymentDetail);
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
