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
    public class roleMenuMappingsController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: roleMenuMappings
        public ActionResult Index()
        {
            return View(db.roleMenuMappings.ToList());
        }

        // GET: roleMenuMappings/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roleMenuMapping roleMenuMapping = db.roleMenuMappings.Find(id);
            if (roleMenuMapping == null)
            {
                return HttpNotFound();
            }
            return View(roleMenuMapping);
        }

        // GET: roleMenuMappings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: roleMenuMappings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "roleMenuMappingId,RoleID,MenuId,AllowInsert,AllowUpdate,AllowDelete,AllowView,IsActive,IsDeleted,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,HostName,IpAddress")] roleMenuMapping roleMenuMapping)
        {
            if (ModelState.IsValid)
            {
                db.roleMenuMappings.Add(roleMenuMapping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleMenuMapping);
        }

        // GET: roleMenuMappings/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roleMenuMapping roleMenuMapping = db.roleMenuMappings.Find(id);
            if (roleMenuMapping == null)
            {
                return HttpNotFound();
            }
            return View(roleMenuMapping);
        }

        // POST: roleMenuMappings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "roleMenuMappingId,RoleID,MenuId,AllowInsert,AllowUpdate,AllowDelete,AllowView,IsActive,IsDeleted,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,HostName,IpAddress")] roleMenuMapping roleMenuMapping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleMenuMapping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleMenuMapping);
        }

        // GET: roleMenuMappings/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roleMenuMapping roleMenuMapping = db.roleMenuMappings.Find(id);
            if (roleMenuMapping == null)
            {
                return HttpNotFound();
            }
            return View(roleMenuMapping);
        }

        // POST: roleMenuMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            roleMenuMapping roleMenuMapping = db.roleMenuMappings.Find(id);
            db.roleMenuMappings.Remove(roleMenuMapping);
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
