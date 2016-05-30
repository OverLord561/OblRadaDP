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
    public class JobsController : Controller
    {
        private OblRadaContext db = new OblRadaContext();

        //
        // GET: /Jobs/

        public ActionResult Index(int? num)
        {

            var jobs = num!=null?db.Jobs.Include(j => j.Factory).Where(x=>x.FactoryId==num) : db.Jobs.Include(j => j.Factory);
            return View(jobs.ToList());
        }
        [HttpPost]
        public ActionResult Index(string job,string duty,string educ)
        {
            var JOBS = db.Jobs.Include(j => j.Factory);
            var JOB = job != "" ? JOBS.Where(x => x.JobName.ToUpper().Contains(job.ToUpper())) : db.Jobs;
            var DUTY = duty != "" ? JOBS.Where(x => x.JobDuties.ToUpper().Contains(duty.ToUpper())) : db.Jobs;
            var EDUC = educ != "" ? JOBS.Where(x => x.JobRequirements.ToUpper().Contains(educ.ToUpper())) : db.Jobs;

            var ALL = JOB.Intersect(DUTY).Intersect(EDUC);

            return View(ALL.ToList());
        }

        //
        // GET: /Jobs/Details/5

        public ActionResult Details(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // GET: /Jobs/Create

        public ActionResult Create()
        {
            ViewBag.FactoryId = new SelectList(db.Factories, "FactoryId", "FactoryName");
            return View();
        }

        //
        // POST: /Jobs/Create

        [HttpPost]
        public ActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FactoryId = new SelectList(db.Factories, "FactoryId", "FactoryName", job.FactoryId);
            return View(job);
        }

        //
        // GET: /Jobs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.FactoryId = new SelectList(db.Factories, "FactoryId", "FactoryName", job.FactoryId);
            return View(job);
        }

        //
        // POST: /Jobs/Edit/5

        [HttpPost]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FactoryId = new SelectList(db.Factories, "FactoryId", "FactoryName", job.FactoryId);
            return View(job);
        }

        //
        // GET: /Jobs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // POST: /Jobs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}