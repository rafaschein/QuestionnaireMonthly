using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuestionnaireMonthly.Domain;
using QuestionnaireMonthly.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace QuestionnaireMonthly.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /User/
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        // GET: /User/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login([Bind(Include = "Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var user_active = db.User.Where(u => u.Email == user.Email && u.Password == user.Password);

                if (user_active.Count() != 0)
                {
                    Response.Cookies["user_active"].Value = user_active.First().ID.ToString();
                    Response.Cookies["user_active"].Expires = DateTime.Now.AddDays(1);

                    return Redirect("/Question/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Usuário e senha incorretos.");
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["user_active"] != null)
            {
                HttpCookie user_active = new HttpCookie("user_active");
                user_active.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(user_active);
            }

            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool isPersistent { get; set; }
    }
}
