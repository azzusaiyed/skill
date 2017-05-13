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
    public class userRolesController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: userRoles
        public ActionResult Index()
        {
            return View(db.userRoles.ToList());
        }

        // GET: userRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userRole userRole = db.userRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // GET: userRoles/Create
        public ActionResult Create()
        {         
            var userMsts = from doc in db.UserMsts
                               orderby doc.UserName, doc.UserId
                               select new SelectListItem { Value= doc.UserId.ToString(), Text= doc.UserName };
            var roleMsts = from doc in db.roleMsts
                           orderby doc.RoleName, doc.RoleId
                           select new SelectListItem { Value = doc.RoleId.ToString(), Text = doc.RoleName };
            ViewBag.UserId = userMsts;
            ViewBag.RoleID = roleMsts;
            return View();
        }

        // POST: userRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userRoleMappingId,userId,RoleId,IsActive,IsDeleted,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,HostName,IpAddress")] userRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.userRoles.Add(userRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRole);
        }

        // GET: userRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userRole userRole = db.userRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: userRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userRoleMappingId,userId,RoleId,IsActive,IsDeleted,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,HostName,IpAddress")] userRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRole);
        }

        // GET: userRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userRole userRole = db.userRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: userRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userRole userRole = db.userRoles.Find(id);
            db.userRoles.Remove(userRole);
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
