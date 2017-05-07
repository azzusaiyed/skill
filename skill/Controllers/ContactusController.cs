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
    public class ContactusController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: Contactus
        public ActionResult Index()
        {
            return View(db.Contactus.ToList());
        }

        // GET: Contactus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contactu contactu = db.Contactus.Find(id);
            if (contactu == null)
            {
                return HttpNotFound();
            }
            return View(contactu);
        }

        // GET: Contactus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contactus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Contactusid,Name,ContactNo,Emailid,Subject,Details,IsActive,IsDeleted,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,HostName,IpAddress")] Contactu contactu)
        {
            if (ModelState.IsValid)
            {
                db.Contactus.Add(contactu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactu);
        }

        // GET: Contactus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contactu contactu = db.Contactus.Find(id);
            if (contactu == null)
            {
                return HttpNotFound();
            }
            return View(contactu);
        }

        // POST: Contactus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Contactusid,Name,ContactNo,Emailid,Subject,Details,IsActive,IsDeleted,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,HostName,IpAddress")] Contactu contactu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactu);
        }

        // GET: Contactus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contactu contactu = db.Contactus.Find(id);
            if (contactu == null)
            {
                return HttpNotFound();
            }
            return View(contactu);
        }

        // POST: Contactus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contactu contactu = db.Contactus.Find(id);
            db.Contactus.Remove(contactu);
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
