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
    public class NoveltiesController : Controller
    {
        private OblRadaContext db = new OblRadaContext();

        //
        // GET: /Novelties/

        public ActionResult Index()
        {
            var top = db.News.Take(5).OrderByDescending(x => x.NoveltyDate).ToList();
            ViewBag.Top = top;
            return View(db.News.ToList());
        }


        public ActionResult Sort()
        {
            return PartialView(db.News.OrderByDescending(x => x.NoveltyDate));

        }
        [HttpPost]
        public ActionResult Sort(string words, DateTime? start, DateTime? end)
        {
            //string[] split =words!=""?words.Split(new Char[] { ' ', '.', ':', '\t' }, StringSplitOptions.RemoveEmptyEntries):null;


            //var WORDS0 = split[0] != "" ? db.News.Where(x => x.NoveltyContent.ToLower().Contains(split[0])) : db.News;
            //var WORDS1 = split[1] == "" ? db.News : db.News.Where(x => x.NoveltyContent.ToLower().Contains(split[1]));
            //var WORDS2 = split[2] != "" ? db.News : db.News.Where(x => x.NoveltyContent.ToLower().Contains(split[2])) ;

            var WORDS = words != "" ? db.News.Where(x => x.NoveltyContent.ToLower().Contains(words.ToLower())) : db.News;

            var START = start != null ? db.News.Where(x => x.NoveltyDate >= start) : db.News;
            var END = end != null ? db.News.Where(x => x.NoveltyDate <= end) : db.News;

            var All = WORDS.Intersect(START).Intersect(END);
            return PartialView(All.OrderByDescending(x=>x.NoveltyDate));
        }

        public ActionResult Review(int num)
        {
            var novost = db.News.Where(x => x.NoveltyId == num);
            return View(novost);
        }
        //
        // GET: /Novelties/Details/5

        public ActionResult Details(int id = 0)
        {
            Novelty novelty = db.News.Find(id);
            if (novelty == null)
            {
                return HttpNotFound();
            }
            return View(novelty);
        }

        //
        // GET: /Novelties/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Novelties/Create

        [HttpPost]
        public ActionResult Create(Novelty novelty)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(novelty);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(novelty);
        }

        //
        // GET: /Novelties/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Novelty novelty = db.News.Find(id);
            if (novelty == null)
            {
                return HttpNotFound();
            }
            return View(novelty);
        }

        //
        // POST: /Novelties/Edit/5

        [HttpPost]
        public ActionResult Edit(Novelty novelty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(novelty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(novelty);
        }

        //
        // GET: /Novelties/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Novelty novelty = db.News.Find(id);
            if (novelty == null)
            {
                return HttpNotFound();
            }
            return View(novelty);
        }

        //
        // POST: /Novelties/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Novelty novelty = db.News.Find(id);
            db.News.Remove(novelty);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}