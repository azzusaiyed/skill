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
    public class CandidateLanguagesController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CandidateLanguages
        public ActionResult Index()
        {
            return View(db.CandidateLanguages.ToList());
        }

        // GET: CandidateLanguages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateLanguage candidateLanguage = db.CandidateLanguages.Find(id);
            if (candidateLanguage == null)
            {
                return HttpNotFound();
            }
            return View(candidateLanguage);
        }

        // GET: CandidateLanguages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateLanguages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CadidateLanguageId,RegistrationId,LanguageMstId")] CandidateLanguage candidateLanguage)
        {
            if (ModelState.IsValid)
            {
                db.CandidateLanguages.Add(candidateLanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidateLanguage);
        }

        // GET: CandidateLanguages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateLanguage candidateLanguage = db.CandidateLanguages.Find(id);
            if (candidateLanguage == null)
            {
                return HttpNotFound();
            }
            return View(candidateLanguage);
        }

        // POST: CandidateLanguages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CadidateLanguageId,RegistrationId,LanguageMstId")] CandidateLanguage candidateLanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateLanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidateLanguage);
        }

        // GET: CandidateLanguages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateLanguage candidateLanguage = db.CandidateLanguages.Find(id);
            if (candidateLanguage == null)
            {
                return HttpNotFound();
            }
            return View(candidateLanguage);
        }

        // POST: CandidateLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CandidateLanguage candidateLanguage = db.CandidateLanguages.Find(id);
            db.CandidateLanguages.Remove(candidateLanguage);
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
