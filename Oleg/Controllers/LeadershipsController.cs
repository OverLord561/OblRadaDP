using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oleg.Models;

namespace Oleg.Controllers
{
    public class LeadershipsController : Controller
    {
        private OblRadaContext db = new OblRadaContext();

        //
        // GET: /Leaderships/

        public ActionResult Index()
        {
            return View(db.Leaderships.ToList());
        }

        //
        // GET: /Leaderships/Details/5

        public ActionResult Details(int id = 0)
        {
            Leadership leadership = db.Leaderships.Find(id);
            if (leadership == null)
            {
                return HttpNotFound();
            }
            return View(leadership);
        }

        //
        // GET: /Leaderships/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Leaderships/Create

        [HttpPost]
        public ActionResult Create(Leadership leadership)
        {
            if (ModelState.IsValid)
            {
                db.Leaderships.Add(leadership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leadership);
        }

        //
        // GET: /Leaderships/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Leadership leadership = db.Leaderships.Find(id);
            if (leadership == null)
            {
                return HttpNotFound();
            }
            return View(leadership);
        }

        //
        // POST: /Leaderships/Edit/5

        [HttpPost]
        public ActionResult Edit(Leadership leadership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leadership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leadership);
        }

        //
        // GET: /Leaderships/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Leadership leadership = db.Leaderships.Find(id);
            if (leadership == null)
            {
                return HttpNotFound();
            }
            return View(leadership);
        }

        //
        // POST: /Leaderships/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Leadership leadership = db.Leaderships.Find(id);
            db.Leaderships.Remove(leadership);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Review(int? num)
        {
            if (num != null)
            {
                HttpContext.Response.Cookies["num_of_film"].Value = num.ToString();
                TempData["num_of_film"] = num;
            }
            else
            {
                num = Convert.ToInt32(HttpContext.Request.Cookies["num_of_film"].Value);
            }
            
            var leader = db.Leaderships.Where(x => x.LeadershipId == num);
            return View(leader);
        }



        public ActionResult LabelView(int num)
        {
            //creates partial label view

            var labels = db.UserComments.Where(s => s.LeadershipId == num).Select(x=> new CustomComment
                {
                    CommentId= x.Id,
                    LeadershipId=x.LeadershipId,
                     User_Name=x.Name,
                     User_LabelText=x.LabelText,
                     Date=x.Date,
                     Admin_Answer=x.Answer
                }).ToList();

            var count = labels.Count();
            ViewBag.Count = count;
            ViewBag.User_Comments_List_ForThisLeader = labels;


            return PartialView();

        }


        public ActionResult Declaration(int LeadershipId)
        {
            //int LeadershipId = Convert.ToInt32((TempData.Peek("leaderid") as string));
            Leadership leader = db.Leaderships.Find(LeadershipId);

            string filename =Server.MapPath(leader.LeadershipDeclaration);
            string contentType ="application/pdf";

            //string DownLoadName=leader.LeadershipName.ToString();


            return File(filename, contentType);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}