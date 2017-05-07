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
    public class LanguageMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: LanguageMasters
        public ActionResult Index()
        {
            return View(db.LanguageMsts.ToList());
        }

        // GET: LanguageMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageMst languageMst = db.LanguageMsts.Find(id);
            if (languageMst == null)
            {
                return HttpNotFound();
            }
            return View(languageMst);
        }

        // GET: LanguageMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguageMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LanguageMstId,LanguageName,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] LanguageMst languageMst)
        {
            if (ModelState.IsValid)
            {
                db.LanguageMsts.Add(languageMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(languageMst);
        }

        // GET: LanguageMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageMst languageMst = db.LanguageMsts.Find(id);
            if (languageMst == null)
            {
                return HttpNotFound();
            }
            return View(languageMst);
        }

        // POST: LanguageMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanguageMstId,LanguageName,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] LanguageMst languageMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(languageMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(languageMst);
        }

        // GET: LanguageMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageMst languageMst = db.LanguageMsts.Find(id);
            if (languageMst == null)
            {
                return HttpNotFound();
            }
            return View(languageMst);
        }

        // POST: LanguageMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LanguageMst languageMst = db.LanguageMsts.Find(id);
            db.LanguageMsts.Remove(languageMst);
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
