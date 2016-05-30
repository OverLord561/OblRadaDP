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
    public class OutlaiesController : Controller
    {
        private OblRadaContext db = new OblRadaContext();

        //
        // GET: /Outlaies/

        public ActionResult Index()
        {
            return View(db.Outlaies.ToList());
        }

        [HttpPost]
        public ActionResult Index(string name, string words, DateTime? start, DateTime? end, string org)
        {

            var NAME = name != "" ? db.Outlaies.Where(x => x.OutlayTitle.ToUpper().Contains(name.ToUpper())) : db.Outlaies;
            var WORDS = words != "" ? db.Outlaies.Where(x => x.OutlayTitle.ToUpper().Contains(words.ToUpper())) : db.Outlaies;
            var START = start != null ? db.Outlaies.Where(x => x.OutlayDate >= start) : db.Outlaies;
            var END = end != null ? db.Outlaies.Where(x => x.OutlayDate <= end) : db.Outlaies;
            var ORG = org!=""?db.Outlaies.Where(x=>x.OutlayOrganization.ToUpper().Contains(org)):db.Outlaies;

            var ALL = NAME.Intersect(WORDS).Intersect(START).Intersect(END).Intersect(ORG);
            return View(ALL.ToList());
        }


        public ActionResult Review(int num)
        {
            var novost = db.Outlaies.Where(x => x.OutlayId == num);
            return View(novost);
        }

        //
        // GET: /Outlaies/Details/5

        public ActionResult Details(int id = 0)
        {
            Outlay outlay = db.Outlaies.Find(id);
            if (outlay == null)
            {
                return HttpNotFound();
            }
            return View(outlay);
        }

        //
        // GET: /Outlaies/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Outlaies/Create

        [HttpPost]
        public ActionResult Create(Outlay outlay)
        {
            if (ModelState.IsValid)
            {
                db.Outlaies.Add(outlay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(outlay);
        }

        //
        // GET: /Outlaies/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Outlay outlay = db.Outlaies.Find(id);
            if (outlay == null)
            {
                return HttpNotFound();
            }
            return View(outlay);
        }

        //
        // POST: /Outlaies/Edit/5

        [HttpPost]
        public ActionResult Edit(Outlay outlay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outlay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(outlay);
        }

        //
        // GET: /Outlaies/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Outlay outlay = db.Outlaies.Find(id);
            if (outlay == null)
            {
                return HttpNotFound();
            }
            return View(outlay);
        }

        //
        // POST: /Outlaies/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Outlay outlay = db.Outlaies.Find(id);
            db.Outlaies.Remove(outlay);
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