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
    public class UserMstrsController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: UserMstrs
        public ActionResult Index()
        {
            return View(db.UserMsts.ToList());
        }

        // GET: UserMstrs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMst userMst = db.UserMsts.Find(id);
            if (userMst == null)
            {
                return HttpNotFound();
            }
            return View(userMst);
        }

        // GET: UserMstrs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserMstrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Email,Password,RoleId,BranchId,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] UserMst userMst)
        {
            if (ModelState.IsValid)
            {
                db.UserMsts.Add(userMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userMst);
        }

        // GET: UserMstrs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMst userMst = db.UserMsts.Find(id);
            if (userMst == null)
            {
                return HttpNotFound();
            }
            return View(userMst);
        }

        // POST: UserMstrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Email,Password,RoleId,BranchId,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress,Host")] UserMst userMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userMst);
        }

        // GET: UserMstrs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMst userMst = db.UserMsts.Find(id);
            if (userMst == null)
            {
                return HttpNotFound();
            }
            return View(userMst);
        }

        // POST: UserMstrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            UserMst userMst = db.UserMsts.Find(id);
            db.UserMsts.Remove(userMst);
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
