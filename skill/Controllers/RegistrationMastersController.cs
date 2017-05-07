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
    public class RegistrationMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: RegistrationMasters
        public ActionResult Index()
        {
            return View(db.RegistrationMsts.ToList());
        }

        // GET: RegistrationMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationMst registrationMst = db.RegistrationMsts.Find(id);
            if (registrationMst == null)
            {
                return HttpNotFound();
            }
            return View(registrationMst);
        }

        // GET: RegistrationMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistrationId,UserName,Email,Password,FirstName,MiddleName,LastName,MobileNumber,DOB,Education,Gender,Age,CityID,StateID,LanguageId,DocumentId")] RegistrationMst registrationMst)
        {
            if (ModelState.IsValid)
            {
                db.RegistrationMsts.Add(registrationMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registrationMst);
        }

        // GET: RegistrationMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationMst registrationMst = db.RegistrationMsts.Find(id);
            if (registrationMst == null)
            {
                return HttpNotFound();
            }
            return View(registrationMst);
        }

        // POST: RegistrationMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrationId,UserName,Email,Password,FirstName,MiddleName,LastName,MobileNumber,DOB,Education,Gender,Age,CityID,StateID,LanguageId,DocumentId")] RegistrationMst registrationMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrationMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrationMst);
        }

        // GET: RegistrationMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationMst registrationMst = db.RegistrationMsts.Find(id);
            if (registrationMst == null)
            {
                return HttpNotFound();
            }
            return View(registrationMst);
        }

        // POST: RegistrationMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistrationMst registrationMst = db.RegistrationMsts.Find(id);
            db.RegistrationMsts.Remove(registrationMst);
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
