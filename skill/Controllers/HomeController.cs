using skill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace skill.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private skillEntities db = new skillEntities();

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserMst model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            //if (ModelState.IsValid)
            {
                using (skillEntities entities = new skillEntities())
                {
                    string username = model.UserName;
                    string password = model.Password;

                    // Now if our password was enctypted or hashed we would have done the
                    // same operation on the user entered password here, But for now
                    // since the password is in plain text lets just authenticate directly

                    bool userValid = entities.UserMsts.Any(user => (user.UserName == username || user.Email == username) && user.Password == password);

                    // User found in the database
                    if (userValid)
                    {
                        FormsAuthentication.SetAuthCookie(username, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Checkout()
        {

            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public PartialViewResult MainNavigation()
        {
            var viewModel = db.menuMsts.OrderBy(o=> o.SeqNo).Where(s=>s.IsActive == true && s.IsDeleted == false).ToList();

            return PartialView("~/Views/partial/_mainNavbar.cshtml", viewModel);
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public PartialViewResult RecentCourse()
        {
            var viewModel = db.CourseMsts.OrderBy(o => o.StartDate).Where(s => s.IsActive == true && s.IsDeleted == false).Take(3).ToList();

            return PartialView("~/Views/partial/_recentCourse.cshtml", viewModel);
        }
    }
}