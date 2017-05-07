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
    public class CandidateJobMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CandidateJobMasters
        public ActionResult Index()
        {
            return View(db.CandidateJobMsts.ToList());
        }

        // GET: CandidateJobMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateJobMst candidateJobMst = db.CandidateJobMsts.Find(id);
            if (candidateJobMst == null)
            {
                return HttpNotFound();
            }
            return View(candidateJobMst);
        }

        // GET: CandidateJobMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateJobMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidateJobId,RegistrationId,CompanyId,IsCertificateIssued,IssueDate,FileName,OfferLetter,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress")] CandidateJobMst candidateJobMst)
        {
            if (ModelState.IsValid)
            {
                db.CandidateJobMsts.Add(candidateJobMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidateJobMst);
        }

        // GET: CandidateJobMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateJobMst candidateJobMst = db.CandidateJobMsts.Find(id);
            if (candidateJobMst == null)
            {
                return HttpNotFound();
            }
            return View(candidateJobMst);
        }

        // POST: CandidateJobMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateJobId,RegistrationId,CompanyId,IsCertificateIssued,IssueDate,FileName,OfferLetter,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress")] CandidateJobMst candidateJobMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateJobMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidateJobMst);
        }

        // GET: CandidateJobMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateJobMst candidateJobMst = db.CandidateJobMsts.Find(id);
            if (candidateJobMst == null)
            {
                return HttpNotFound();
            }
            return View(candidateJobMst);
        }

        // POST: CandidateJobMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CandidateJobMst candidateJobMst = db.CandidateJobMsts.Find(id);
            db.CandidateJobMsts.Remove(candidateJobMst);
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
