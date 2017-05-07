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
    public class DistrictMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: DistrictMasters
        public ActionResult Index()
        {
            return View(db.DistrictMsts.ToList());
        }

        // GET: DistrictMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistrictMst districtMst = db.DistrictMsts.Find(id);
            if (districtMst == null)
            {
                return HttpNotFound();
            }
            return View(districtMst);
        }

        // GET: DistrictMasters/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.StateMsts.OrderBy(o => o.StateName), "StateId", "StateName", string.Empty);

            return View();
        }

        // POST: DistrictMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistrictId,StateId,DistrictName,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] DistrictMst districtMst)
        {
            if (ModelState.IsValid)
            {
                db.DistrictMsts.Add(districtMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(districtMst);
        }

        // GET: DistrictMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistrictMst districtMst = db.DistrictMsts.Find(id);
            if (districtMst == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.StateMsts.OrderBy(o => o.StateName), "StateId", "StateName", districtMst.StateId);
            return View(districtMst);
        }

        // POST: DistrictMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistrictId,StateId,DistrictName,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] DistrictMst districtMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(districtMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(districtMst);
        }

        // GET: DistrictMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistrictMst districtMst = db.DistrictMsts.Find(id);
            if (districtMst == null)
            {
                return HttpNotFound();
            }
            return View(districtMst);
        }

        // POST: DistrictMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DistrictMst districtMst = db.DistrictMsts.Find(id);
            db.DistrictMsts.Remove(districtMst);
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
