using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using JobShop.Models;

namespace JobShop
{
    public class CandidatesController : Controller
    {
        private JobShopEntities db = new JobShopEntities();

        // GET: Candidates
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //stuff for paging, searching and sorting
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            //         
            var candidates = db.Candidates.Include(c => c.AspNetUsers);

            //Some search stuff
            if (!String.IsNullOrEmpty(searchString))
            {
                candidates = candidates.Where(s => s.Titlu.Contains(searchString)
                                       || s.Description.Contains(searchString));
            }
            //
            switch (sortOrder)
            {
                case "name_desc":
                    candidates = candidates.OrderByDescending(s => s.Titlu);
                    break;
                case "Date":
                    candidates = candidates.OrderBy(s => s.DateAdd);
                    break;
                case "date_desc":
                    candidates = candidates.OrderByDescending(s => s.DateAdd);
                    break;
                default:
                    //jobs = jobs.OrderBy(s => s.Titlu);
                    candidates = candidates.OrderBy(s => s.DateAdd);
                    break;
            }
            //
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(candidates.ToPagedList(pageNumber, pageSize));

            //return View(candidates.ToList());
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidates candidates = db.Candidates.Find(id);
            if (candidates == null)
            {
                return HttpNotFound();
            }
            return View(candidates);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCV,User,Experienta,Latitudine,Longitudine,address,ZIP")] Candidates candidates)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email", candidates.User);
            return View(candidates);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidates candidates = db.Candidates.Find(id);
            if (candidates == null)
            {
                return HttpNotFound();
            }
            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email", candidates.User);
            return View(candidates);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCV,User,Experienta,Latitudine,Longitudine,address,ZIP")] Candidates candidates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email", candidates.User);
            return View(candidates);
        }

        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidates candidates = db.Candidates.Find(id);
            if (candidates == null)
            {
                return HttpNotFound();
            }
            return View(candidates);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidates candidates = db.Candidates.Find(id);
            db.Candidates.Remove(candidates);
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
