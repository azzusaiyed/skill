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
    public class SiteConfigsController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: SiteConfigs
        public ActionResult Index()
        {
            return View(db.SiteConfigs.ToList());
        }

        // GET: SiteConfigs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteConfig siteConfig = db.SiteConfigs.Find(id);
            if (siteConfig == null)
            {
                return HttpNotFound();
            }
            return View(siteConfig);
        }

        // GET: SiteConfigs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteConfigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteConfigId,errorMailTo,errorMailCC")] SiteConfig siteConfig)
        {
            if (ModelState.IsValid)
            {
                db.SiteConfigs.Add(siteConfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteConfig);
        }

        // GET: SiteConfigs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteConfig siteConfig = db.SiteConfigs.Find(id);
            if (siteConfig == null)
            {
                return HttpNotFound();
            }
            return View(siteConfig);
        }

        // POST: SiteConfigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiteConfigId,errorMailTo,errorMailCC")] SiteConfig siteConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteConfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteConfig);
        }

        // GET: SiteConfigs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteConfig siteConfig = db.SiteConfigs.Find(id);
            if (siteConfig == null)
            {
                return HttpNotFound();
            }
            return View(siteConfig);
        }

        // POST: SiteConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteConfig siteConfig = db.SiteConfigs.Find(id);
            db.SiteConfigs.Remove(siteConfig);
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
