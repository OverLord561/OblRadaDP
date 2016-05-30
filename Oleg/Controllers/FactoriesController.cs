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
    public class FactoriesController : Controller
    {
        private OblRadaContext db = new OblRadaContext();

        //
        // GET: /Factories/

        public ActionResult Index(string type)
        {
            //var firm = db.Factories.Select(new {}) GroupBy(x => x.FactoryType);
            //var firm = from p in db.Factories
            //             group p by p.FactoryType;
            var firm = db.Factories.Select(x => new TypeOfFactories { 
            Type=x.FactoryType           
            }).Distinct();

            ViewBag.Firms = firm.ToList();

            var TYPE = type!=null?db.Factories.Where(x => x.FactoryType.Contains(type)):db.Factories;
            return View(TYPE);
        }

        //
        // GET: /Factories/Details/5

        public ActionResult Details(int id = 0)
        {
            Factory factory = db.Factories.Find(id);
            if (factory == null)
            {
                return HttpNotFound();
            }
            return View(factory);
        }

        //
        // GET: /Factories/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Factories/Create

        [HttpPost]
        public ActionResult Create(Factory factory)
        {
            if (ModelState.IsValid)
            {
                db.Factories.Add(factory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factory);
        }

        //
        // GET: /Factories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Factory factory = db.Factories.Find(id);
            if (factory == null)
            {
                return HttpNotFound();
            }
            return View(factory);
        }

        //
        // POST: /Factories/Edit/5

        [HttpPost]
        public ActionResult Edit(Factory factory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factory);
        }

        //
        // GET: /Factories/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Factory factory = db.Factories.Find(id);
            if (factory == null)
            {
                return HttpNotFound();
            }
            return View(factory);
        }

        //
        // POST: /Factories/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Factory factory = db.Factories.Find(id);
            db.Factories.Remove(factory);
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