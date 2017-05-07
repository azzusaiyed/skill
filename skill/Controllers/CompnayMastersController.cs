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
    public class CompnayMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CompnayMasters
        public ActionResult Index()
        {
            return View(db.CompnayMsts.ToList());
        }

        // GET: CompnayMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompnayMst compnayMst = db.CompnayMsts.Find(id);
            if (compnayMst == null)
            {
                return HttpNotFound();
            }
            return View(compnayMst);
        }

        // GET: CompnayMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompnayMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CopmanyId,CompanyName,CompanyAbb,Address,Email,ContantNo,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CompnayMst compnayMst)
        {
            if (ModelState.IsValid)
            {
                db.CompnayMsts.Add(compnayMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compnayMst);
        }

        // GET: CompnayMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompnayMst compnayMst = db.CompnayMsts.Find(id);
            if (compnayMst == null)
            {
                return HttpNotFound();
            }
            return View(compnayMst);
        }

        // POST: CompnayMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CopmanyId,CompanyName,CompanyAbb,Address,Email,ContantNo,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CompnayMst compnayMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compnayMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compnayMst);
        }

        // GET: CompnayMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompnayMst compnayMst = db.CompnayMsts.Find(id);
            if (compnayMst == null)
            {
                return HttpNotFound();
            }
            return View(compnayMst);
        }

        // POST: CompnayMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompnayMst compnayMst = db.CompnayMsts.Find(id);
            db.CompnayMsts.Remove(compnayMst);
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
