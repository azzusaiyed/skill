using skill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace skill.Controllers
{
    public class HomeController : Controller
    {
        private skillEntities db = new skillEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CourseDetails(int? id)
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

        [ChildActionOnly]
        public PartialViewResult MainNavigation()
        {
            var viewModel = db.menuMsts.OrderBy(o=> o.SeqNo).Where(s=>s.IsActive == true && s.IsDeleted == false).ToList();

            return PartialView("~/Views/partial/_mainNavbar.cshtml", viewModel);
        }

        [ChildActionOnly]
        public PartialViewResult RecentCourse()
        {
            var viewModel = db.CourseMsts.OrderBy(o => o.StartDate).Where(s => s.IsActive == true && s.IsDeleted == false).Take(3).ToList();

            return PartialView("~/Views/partial/_recentCourse.cshtml", viewModel);
        }
    }
}