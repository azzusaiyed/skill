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
    public class CityMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CityMasters
        public ActionResult Index()
        {
            return View(db.CityMsts.ToList());
        }

        // GET: CityMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityMst cityMst = db.CityMsts.Find(id);
            if (cityMst == null)
            {
                return HttpNotFound();
            }
            return View(cityMst);
        }

        // GET: CityMasters/Create
        public ActionResult Create()
        {
            var districtMsts = from doc in db.DistrictMsts
                               orderby doc.DistrictName, doc.DistrictId
                               select new SelectListItem { Value = doc.DistrictId.ToString(), Text = doc.DistrictName };
            ViewBag.DistrictId = districtMsts;

            return View();
        }

        // POST: CityMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,DistrictId,CityName,Pincode,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CityMst cityMst)
        {
            if (ModelState.IsValid)
            {
                db.CityMsts.Add(cityMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityMst);
        }

        // GET: CityMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityMst cityMst = db.CityMsts.Find(id);
            if (cityMst == null)
            {
                return HttpNotFound();
            }
            return View(cityMst);
        }

        // POST: CityMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,DistrictId,CityName,Pincode,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] CityMst cityMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityMst);
        }

        // GET: CityMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityMst cityMst = db.CityMsts.Find(id);
            if (cityMst == null)
            {
                return HttpNotFound();
            }
            return View(cityMst);
        }

        // POST: CityMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityMst cityMst = db.CityMsts.Find(id);
            db.CityMsts.Remove(cityMst);
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
