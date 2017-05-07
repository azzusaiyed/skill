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
    public class StateMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: StateMasters
        public ActionResult Index()
        {
            return View(db.StateMsts.ToList());
        }

        // GET: StateMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMst stateMst = db.StateMsts.Find(id);
            if (stateMst == null)
            {
                return HttpNotFound();
            }
            return View(stateMst);
        }

        // GET: StateMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,StateName,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] StateMst stateMst)
        {
            if (ModelState.IsValid)
            {
                db.StateMsts.Add(stateMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stateMst);
        }

        // GET: StateMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMst stateMst = db.StateMsts.Find(id);
            if (stateMst == null)
            {
                return HttpNotFound();
            }
            return View(stateMst);
        }

        // POST: StateMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateId,StateName,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] StateMst stateMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stateMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stateMst);
        }

        // GET: StateMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateMst stateMst = db.StateMsts.Find(id);
            if (stateMst == null)
            {
                return HttpNotFound();
            }
            return View(stateMst);
        }

        // POST: StateMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StateMst stateMst = db.StateMsts.Find(id);
            db.StateMsts.Remove(stateMst);
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
