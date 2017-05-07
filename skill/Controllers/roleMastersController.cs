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
    public class roleMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: roleMasters
        public ActionResult Index()
        {
            return View(db.roleMsts.ToList());
        }

        // GET: roleMasters/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roleMst roleMst = db.roleMsts.Find(id);
            if (roleMst == null)
            {
                return HttpNotFound();
            }
            return View(roleMst);
        }

        // GET: roleMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: roleMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleID,RoleType,RoleName,IsActive,IsDeleted,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,HostName,IpAddress")] roleMst roleMst)
        {
            if (ModelState.IsValid)
            {
                db.roleMsts.Add(roleMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleMst);
        }

        // GET: roleMasters/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roleMst roleMst = db.roleMsts.Find(id);
            if (roleMst == null)
            {
                return HttpNotFound();
            }
            return View(roleMst);
        }

        // POST: roleMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleID,RoleType,RoleName,IsActive,IsDeleted,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,HostName,IpAddress")] roleMst roleMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleMst);
        }

        // GET: roleMasters/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roleMst roleMst = db.roleMsts.Find(id);
            if (roleMst == null)
            {
                return HttpNotFound();
            }
            return View(roleMst);
        }

        // POST: roleMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            roleMst roleMst = db.roleMsts.Find(id);
            db.roleMsts.Remove(roleMst);
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
