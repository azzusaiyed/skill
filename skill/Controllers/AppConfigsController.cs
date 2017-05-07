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
    public class AppConfigsController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: AppConfigs
        public ActionResult Index()
        {
            return View(db.AppConfigs.ToList());
        }

        // GET: AppConfigs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppConfig appConfig = db.AppConfigs.Find(id);
            if (appConfig == null)
            {
                return HttpNotFound();
            }
            return View(appConfig);
        }

        // GET: AppConfigs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppConfigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppConfigId,Appkey,AppValue,Remarks")] AppConfig appConfig)
        {
            if (ModelState.IsValid)
            {
                db.AppConfigs.Add(appConfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appConfig);
        }

        // GET: AppConfigs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppConfig appConfig = db.AppConfigs.Find(id);
            if (appConfig == null)
            {
                return HttpNotFound();
            }
            return View(appConfig);
        }

        // POST: AppConfigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppConfigId,Appkey,AppValue,Remarks")] AppConfig appConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appConfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appConfig);
        }

        // GET: AppConfigs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppConfig appConfig = db.AppConfigs.Find(id);
            if (appConfig == null)
            {
                return HttpNotFound();
            }
            return View(appConfig);
        }

        // POST: AppConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppConfig appConfig = db.AppConfigs.Find(id);
            db.AppConfigs.Remove(appConfig);
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
