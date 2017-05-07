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
    public class CandidateDocumentsController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CandidateDocuments
        public ActionResult Index()
        {
            return View(db.CandidateDocs.ToList());
        }

        // GET: CandidateDocuments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateDoc candidateDoc = db.CandidateDocs.Find(id);
            if (candidateDoc == null)
            {
                return HttpNotFound();
            }
            return View(candidateDoc);
        }

        // GET: CandidateDocuments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateDocuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidateDocId,RegistrationId,DocumentMstId,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CandidateDoc candidateDoc)
        {
            if (ModelState.IsValid)
            {
                db.CandidateDocs.Add(candidateDoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidateDoc);
        }

        // GET: CandidateDocuments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateDoc candidateDoc = db.CandidateDocs.Find(id);
            if (candidateDoc == null)
            {
                return HttpNotFound();
            }
            return View(candidateDoc);
        }

        // POST: CandidateDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateDocId,RegistrationId,DocumentMstId,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CandidateDoc candidateDoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateDoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidateDoc);
        }

        // GET: CandidateDocuments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateDoc candidateDoc = db.CandidateDocs.Find(id);
            if (candidateDoc == null)
            {
                return HttpNotFound();
            }
            return View(candidateDoc);
        }

        // POST: CandidateDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CandidateDoc candidateDoc = db.CandidateDocs.Find(id);
            db.CandidateDocs.Remove(candidateDoc);
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
