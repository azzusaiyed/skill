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
    public class DocumentMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: DocumentMasters
        public ActionResult Index()
        {
            return View(db.DocumentMsts.ToList());
        }

        // GET: DocumentMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentMst documentMst = db.DocumentMsts.Find(id);
            if (documentMst == null)
            {
                return HttpNotFound();
            }
            return View(documentMst);
        }

        // GET: DocumentMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentMstId,DocName,DocTitle,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] DocumentMst documentMst)
        {
            if (ModelState.IsValid)
            {
                db.DocumentMsts.Add(documentMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(documentMst);
        }

        // GET: DocumentMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentMst documentMst = db.DocumentMsts.Find(id);
            if (documentMst == null)
            {
                return HttpNotFound();
            }
            return View(documentMst);
        }

        // POST: DocumentMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentMstId,DocName,DocTitle,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] DocumentMst documentMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documentMst);
        }

        // GET: DocumentMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentMst documentMst = db.DocumentMsts.Find(id);
            if (documentMst == null)
            {
                return HttpNotFound();
            }
            return View(documentMst);
        }

        // POST: DocumentMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentMst documentMst = db.DocumentMsts.Find(id);
            db.DocumentMsts.Remove(documentMst);
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
