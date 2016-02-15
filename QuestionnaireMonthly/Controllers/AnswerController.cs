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

namespace QuestionnaireMonthly.Controllers
{
    public class AnswerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Answer/
        public ActionResult Index()
        {
            return View(db.Answer.ToList());
        }

        // POST: /Answer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QuestionID,UserID,Response,Date")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answer.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(answer);
        }

        // GET: /Answer/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: /Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Answer answer = db.Answer.Find(id);
            db.Answer.Remove(answer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Question(long id)
        {
            var Question = db.Question.Find(id);
            var User = db.User.Find(Int32.Parse(Request.Cookies["user_active"].Value));

            var answer = new Answer
            {
                Question = Question,
                User = User,
                QuestionID = Int32.Parse(Question.ID.ToString()),
                UserID = Int32.Parse(User.ID.ToString())
            };

            return View(answer);
        }

        public ActionResult Answer()
        {
            
            var Question = db.Question.OrderBy(question => question.Order).First();
            var User = db.User.Find(Int32.Parse(Request.Cookies["user_active"].Value));

            var answer = new Answer
            {
                Question = Question,
                User = User,
                QuestionID = Int32.Parse(Question.ID.ToString()),
                UserID = Int32.Parse(User.ID.ToString())
            };

            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Answer([Bind(Include = "ID,QuestionID,UserID,Response,Date")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answer.Add(answer);
                db.SaveChanges();

                var current_question = db.Question.Find(answer.QuestionID);

                var Question = GetNextQuestion(answer.QuestionID, current_question.Order);
                
                if (Question != null)
                {
                    var User = db.User.Find(Int32.Parse(Request.Cookies["user_active"].Value));

                    var next_question = new Answer
                    {
                        UserID = User.ID,
                        Date = answer.Date,
                        Question = Question,
                        QuestionID = Int32.Parse(Question.ID.ToString()),
                        User = User,
                        Response = false
                    };

                    return View(next_question);
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }

            return View(answer);
        }

        private Question GetNextQuestion(long id, int order)
        {
            var Question = db.Question.Where(question => question.ID != id && question.Order > order).OrderBy(question => question.Order);

            if (Question.Count() > 0)
            {
                return Question.First();
            }
            else
            {
                return null;
            }
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
