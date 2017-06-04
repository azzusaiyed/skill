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
    [Authorize]
    public class CandidateAttendancesController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CandidateAttendances
        public ActionResult Index()
        {
            return View(db.CandidateAttendances.ToList());
        }

        // GET: CandidateAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateAttendance candidateAttendance = db.CandidateAttendances.Find(id);
            if (candidateAttendance == null)
            {
                return HttpNotFound();
            }
            return View(candidateAttendance);
        }

        // GET: CandidateAttendances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidateAttendanceId,CourseId,RegistationId,DateTimeIn,DateTimeOut,AttandanceHour,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CandidateAttendance candidateAttendance)
        {
            if (ModelState.IsValid)
            {
                db.CandidateAttendances.Add(candidateAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidateAttendance);
        }

        // GET: CandidateAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateAttendance candidateAttendance = db.CandidateAttendances.Find(id);
            if (candidateAttendance == null)
            {
                return HttpNotFound();
            }
            return View(candidateAttendance);
        }

        // POST: CandidateAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateAttendanceId,CourseId,RegistationId,DateTimeIn,DateTimeOut,AttandanceHour,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CandidateAttendance candidateAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidateAttendance);
        }

        // GET: CandidateAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateAttendance candidateAttendance = db.CandidateAttendances.Find(id);
            if (candidateAttendance == null)
            {
                return HttpNotFound();
            }
            return View(candidateAttendance);
        }

        // POST: CandidateAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CandidateAttendance candidateAttendance = db.CandidateAttendances.Find(id);
            db.CandidateAttendances.Remove(candidateAttendance);
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
