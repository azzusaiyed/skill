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
    public class CategoryMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CategoryMasters
        public ActionResult Index()
        {
            return View(db.CategoryMsts.ToList());
        }
        
        // GET: CategoryMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMst categoryMst = db.CategoryMsts.Find(id);
            if (categoryMst == null)
            {
                return HttpNotFound();
            }
            return View(categoryMst);
        }

        // GET: CategoryMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,CategoryAbb,SeqNo,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CategoryMst categoryMst)
        {
            if (ModelState.IsValid)
            {
                //[TODO]
                categoryMst.CreatedBy = 1;
                categoryMst.CreatedDate = DateTime.Now;
                categoryMst.ModifyBy = 1;
                categoryMst.ModifyDate = DateTime.Now;
                categoryMst.Host = "";
                categoryMst.IpAddress = "";

                db.CategoryMsts.Add(categoryMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryMst);
        }

        // GET: CategoryMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMst categoryMst = db.CategoryMsts.Find(id);
            if (categoryMst == null)
            {
                return HttpNotFound();
            }
            return View(categoryMst);
        }

        // POST: CategoryMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,CategoryAbb,SeqNo,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CategoryMst categoryMst)
        {
            if (ModelState.IsValid)
            {
                //[TODO]
                categoryMst.ModifyBy = 1;
                categoryMst.ModifyDate = DateTime.Now;

                db.Entry(categoryMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryMst);
        }

        // GET: CategoryMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMst categoryMst = db.CategoryMsts.Find(id);
            if (categoryMst == null)
            {
                return HttpNotFound();
            }
            return View(categoryMst);
        }

        // POST: CategoryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryMst categoryMst = db.CategoryMsts.Find(id);
            db.CategoryMsts.Remove(categoryMst);
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
