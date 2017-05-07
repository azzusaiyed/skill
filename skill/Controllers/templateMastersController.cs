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
    public class templateMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: templateMasters
        public ActionResult Index()
        {
            return View(db.templateMsts.ToList());
        }

        // GET: templateMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            templateMst templateMst = db.templateMsts.Find(id);
            if (templateMst == null)
            {
                return HttpNotFound();
            }
            return View(templateMst);
        }

        // GET: templateMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: templateMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TemplateId,Name,ParentTemplateId,DisplayOrder,Detail,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted")] templateMst templateMst)
        {
            if (ModelState.IsValid)
            {
                db.templateMsts.Add(templateMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(templateMst);
        }

        // GET: templateMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            templateMst templateMst = db.templateMsts.Find(id);
            if (templateMst == null)
            {
                return HttpNotFound();
            }
            return View(templateMst);
        }

        // POST: templateMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TemplateId,Name,ParentTemplateId,DisplayOrder,Detail,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted")] templateMst templateMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(templateMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(templateMst);
        }

        // GET: templateMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            templateMst templateMst = db.templateMsts.Find(id);
            if (templateMst == null)
            {
                return HttpNotFound();
            }
            return View(templateMst);
        }

        // POST: templateMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            templateMst templateMst = db.templateMsts.Find(id);
            db.templateMsts.Remove(templateMst);
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
