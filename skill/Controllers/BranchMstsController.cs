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
    public class BranchMstsController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: BranchMsts
        public ActionResult Index()
        {
            return View(db.BranchMsts.ToList());
        }

        // GET: BranchMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchMst branchMst = db.BranchMsts.Find(id);
            if (branchMst == null)
            {
                return HttpNotFound();
            }
            return View(branchMst);
        }

        // GET: BranchMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BranchMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BranchId,CityId,BranchName,BranchAddress,EmailId,MobileNo,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] BranchMst branchMst)
        {
            if (ModelState.IsValid)
            {
                db.BranchMsts.Add(branchMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branchMst);
        }

        // GET: BranchMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchMst branchMst = db.BranchMsts.Find(id);
            if (branchMst == null)
            {
                return HttpNotFound();
            }
            return View(branchMst);
        }

        // POST: BranchMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BranchId,CityId,BranchName,BranchAddress,EmailId,MobileNo,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] BranchMst branchMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branchMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branchMst);
        }

        // GET: BranchMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchMst branchMst = db.BranchMsts.Find(id);
            if (branchMst == null)
            {
                return HttpNotFound();
            }
            return View(branchMst);
        }

        // POST: BranchMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BranchMst branchMst = db.BranchMsts.Find(id);
            db.BranchMsts.Remove(branchMst);
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
