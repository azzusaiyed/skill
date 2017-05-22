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
            return View(this.GetContactUs(1));
        }

        [HttpPost]
        public ActionResult Index(int currentPageIndex)
        {
            return View(this.GetContactUs(currentPageIndex));
        }

        private ContactUsModel GetContactUs(int currentPage)
        {
            int maxRows = 2;

            ContactUsModel ContactUsModel = new ContactUsModel();

            ContactUsModel.ContactUs = (from ContactUs in db.Contactus
                                             select ContactUs)
                        .OrderBy(Contactus => Contactus.Contactusid)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList();

            double pageCount = (double)((decimal)db.Contactus.Count() / Convert.ToDecimal(maxRows));
            ContactUsModel.PageCount = (int)Math.Ceiling(pageCount);

            ContactUsModel.CurrentPageIndex = currentPage;

            return ContactUsModel;
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
                //[TODO]
                contactu.CreatedBy = 1;
                contactu.CreatedDate = DateTime.Now;
                contactu.ModifiedBy = 1;
                contactu.ModifiedDate = DateTime.Now;
                contactu.HostName = "";
                contactu.IpAddress = "";

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
                //[TODO]
                contactu.ModifiedBy = 1;
                contactu.ModifiedDate = DateTime.Now;
                contactu.HostName = "";
                contactu.IpAddress = "";

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
