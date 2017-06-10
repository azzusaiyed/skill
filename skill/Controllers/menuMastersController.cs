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
    public class menuMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: menuMasters
        public ActionResult Index()
        {
            return View(db.menuMsts.ToList());
        }

        // GET: menuMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menuMst menuMst = db.menuMsts.Find(id);
            if (menuMst == null)
            {
                return HttpNotFound();
            }
            return View(menuMst);
        }

        // GET: menuMasters/Create
        public ActionResult Create()
        {
            ViewBag.ParentMenuID = new SelectList(db.menuMsts.OrderBy(o=> o.Name).Where(s => s.IsActive == true && s.IsDeleted == false && s.ShowInMenu == true), "MenuID", "Name", "--Select--");
            return View();
        }

        // POST: menuMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuID,ParentMenuID,MenuType,IsAdminPage,Name,NameGuj,URL,ShowInMenu,Icon,SeqNo,IsActive,IsDeleted,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,HostName,IpAddress")] menuMst menuMst)
        {
            if (ModelState.IsValid)
            {
                //[TODO]
                menuMst.CreatedBy = 1;
                menuMst.CreatedDate = DateTime.Now;
                menuMst.ModifiedBy = 1;
                menuMst.ModifiedDate = DateTime.Now;
                menuMst.IpAddress = "";
                menuMst.HostName = "";

                db.menuMsts.Add(menuMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuMst);
        }

        // GET: menuMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menuMst menuMst = db.menuMsts.Find(id);
            if (menuMst == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentMenuID = new SelectList(db.menuMsts.OrderBy(o => o.Name).Where(s => s.IsActive == true && s.IsDeleted == false && s.ShowInMenu == true), "MenuID", "Name", menuMst.ParentMenuID);
            return View(menuMst);
        }

        // POST: menuMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuID,ParentMenuID,MenuType,IsAdminPage,Name,NameGuj,URL,ShowInMenu,Icon,SeqNo,IsActive,IsDeleted,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,HostName,IpAddress")] menuMst menuMst)
        {
            if (ModelState.IsValid)
            {
                //[TODO]
                menuMst.CreatedBy = 1;
                menuMst.CreatedDate = DateTime.Now;
                menuMst.ModifiedBy = 1;
                menuMst.ModifiedDate = DateTime.Now;
                menuMst.IpAddress = "";
                menuMst.HostName = "";

                db.Entry(menuMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuMst);
        }

        // GET: menuMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menuMst menuMst = db.menuMsts.Find(id);
            if (menuMst == null)
            {
                return HttpNotFound();
            }
            return View(menuMst);
        }

        // POST: menuMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            menuMst menuMst = db.menuMsts.Find(id);
            db.menuMsts.Remove(menuMst);
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
