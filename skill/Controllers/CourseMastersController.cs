using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using skill.Models;
using System.IO;

namespace skill.Controllers
{
    [Authorize]
    public class CourseMastersController : Controller
    {
        private skillEntities db = new skillEntities();

        // GET: CourseMasters
        public ActionResult Index()
        {
            return View(db.CourseMsts.ToList());
        }

        // GET: CourseMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseMst courseMst = db.CourseMsts.Find(id);
            if (courseMst == null)
            {
                return HttpNotFound();
            }
            return View(courseMst);
        }

        // GET: CourseMasters/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.CategoryMsts.Where(s => s.IsActive == true && s.IsDeleted == false), "CategoryId", "CategoryName", "--Select--");
            ViewBag.TrainerId = new SelectList(db.TrainerMsts.Where(s => s.IsActive == true && s.IsDeleted == false), "TrainerId", "Name", "--Select--");
            ViewBag.BranchId = new SelectList(db.BranchMsts.Where(s => s.IsActive == true && s.IsDeleted == false), "BranchId", "BranchName", "--Select--");
            ViewBag.CourseDocId = new SelectList(db.CourseDocMappings.Where(s => s.IsActive == true && s.IsDeleted == false), "CourseDocMappingId", "DocTitle", "--Select--");


            return View();
        }

        // POST: CourseMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase postedFile, HttpPostedFileBase coursePDFFile, [Bind(Include = "CourseId,CategoryId,TrainerId,BranchId,CourseName,CourseAbb,ShotDescription,Overview,Description,OfflineSeat,OnlineSeat,StartDate,EndDate,DurationInHours,ExtentionDate,PendingOnlineSeat,PendingOfflineSeat,AvgRating,CoursePDF,CoursePhoto,CourseVideoYouTubeLink,CourseDocId,CourseFee,CourseInitialFee,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress")] CourseMst courseMst)
        {
            if (ModelState.IsValid)
            {
                //[TODO]
                courseMst.CreatedBy = 1;
                courseMst.CreatedDate = DateTime.Now;
                courseMst.ModifyBy = 1;
                courseMst.ModifyDate = DateTime.Now;
                courseMst.IpAddress = "";

                db.CourseMsts.Add(courseMst);
                db.SaveChanges();

                var id = courseMst.CourseId;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/Course/" + courseMst.CourseId + "/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
                    courseMst.CoursePhoto = "/Uploads/Course/" + courseMst.CourseId + "/" + Path.GetFileName(postedFile.FileName);

                    db.Entry(courseMst).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (coursePDFFile != null)
                {
                    string path = Server.MapPath("~/Uploads/Course/" + courseMst.CourseId + "/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    coursePDFFile.SaveAs(path + Path.GetFileName(coursePDFFile.FileName));
                    courseMst.CoursePDF = "/Uploads/Course/" + courseMst.CourseId + "/" + Path.GetFileName(coursePDFFile.FileName);

                    db.Entry(courseMst).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(courseMst);
        }

        // GET: CourseMasters/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseMst courseMst = db.CourseMsts.Find(id);
            if (courseMst == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.CategoryMsts.Where(s => s.IsActive == true && s.IsDeleted == false), "CategoryId", "CategoryName", "--Select--");
            ViewBag.TrainerId = new SelectList(db.TrainerMsts.Where(s => s.IsActive == true && s.IsDeleted == false), "TrainerId", "Name", "--Select--");
            ViewBag.BranchId = new SelectList(db.BranchMsts.Where(s => s.IsActive == true && s.IsDeleted == false), "BranchId", "BranchName", "--Select--");
            ViewBag.CourseDocId = new SelectList(db.CourseDocMappings.Where(s => s.IsActive == true && s.IsDeleted == false), "CourseDocMappingId", "DocTitle", "--Select--");

            return View(courseMst);
        }

        // POST: CourseMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase postedFile, HttpPostedFileBase coursePDFFile, [Bind(Include = "CourseId,CategoryId,TrainerId,BranchId,CourseName,CourseAbb,ShotDescription,Overview,Description,OfflineSeat,OnlineSeat,StartDate,EndDate,DurationInHours,ExtentionDate,PendingOnlineSeat,PendingOfflineSeat,AvgRating,CoursePDF,CoursePhoto,CourseVideoYouTubeLink,CourseDocId,CourseFee,CourseInitialFee,CreatedDate,CreatedBy,ModifyDate,ModifyBy,IsActive,IsDeleted,IpAddress")] CourseMst courseMst)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/Course/" + courseMst.CourseId + "/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
                    courseMst.CoursePhoto = "/Uploads/Course/" + courseMst.CourseId + "/" + Path.GetFileName(postedFile.FileName);
                }
                if (coursePDFFile != null)
                {
                    string path = Server.MapPath("~/Uploads/Course/" + courseMst.CourseId + "/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    coursePDFFile.SaveAs(path + Path.GetFileName(coursePDFFile.FileName));
                    courseMst.CoursePDF = "/Uploads/Course/" + courseMst.CourseId + "/" + Path.GetFileName(coursePDFFile.FileName);
                }

                //[TODO]
                courseMst.CreatedBy = 1;
                courseMst.CreatedDate = DateTime.Now;
                courseMst.ModifyBy = 1;
                courseMst.ModifyDate = DateTime.Now;
                courseMst.IpAddress = "";

                db.Entry(courseMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseMst);
        }

        // GET: CourseMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseMst courseMst = db.CourseMsts.Find(id);
            if (courseMst == null)
            {
                return HttpNotFound();
            }
            return View(courseMst);
        }

        // POST: CourseMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseMst courseMst = db.CourseMsts.Find(id);
            db.CourseMsts.Remove(courseMst);
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
