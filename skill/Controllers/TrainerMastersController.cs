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
    public class TrainerMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: TrainerMasters
        public ActionResult Index()
        {
            return View(db.TrainerMsts.ToList());
        }

        // GET: TrainerMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerMst trainerMst = db.TrainerMsts.Find(id);
            if (trainerMst == null)
            {
                return HttpNotFound();
            }
            return View(trainerMst);
        }

        // GET: TrainerMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainerMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerId,Name,EmailId,MobileNo,Qualification,ShortDetail,Details,Photo,Gender,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress")] TrainerMst trainerMst)
        {
            if (ModelState.IsValid)
            {
                db.TrainerMsts.Add(trainerMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainerMst);
        }

        // GET: TrainerMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerMst trainerMst = db.TrainerMsts.Find(id);
            if (trainerMst == null)
            {
                return HttpNotFound();
            }
            return View(trainerMst);
        }

        // POST: TrainerMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainerId,Name,EmailId,MobileNo,Qualification,ShortDetail,Details,Photo,Gender,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress")] TrainerMst trainerMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainerMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainerMst);
        }

        // GET: TrainerMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerMst trainerMst = db.TrainerMsts.Find(id);
            if (trainerMst == null)
            {
                return HttpNotFound();
            }
            return View(trainerMst);
        }

        // POST: TrainerMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainerMst trainerMst = db.TrainerMsts.Find(id);
            db.TrainerMsts.Remove(trainerMst);
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
