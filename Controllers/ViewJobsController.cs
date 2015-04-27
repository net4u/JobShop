using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobShop;

namespace JobShop.Controllers
{
    public class ViewJobsController : Controller
    {
        private JobShopEntities db = new JobShopEntities();

        // GET: ViewJobs
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.AspNetUsers);
            return View(jobs.ToList());
        }

        // GET: ViewJobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.Jobs.Find(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }

        // GET: ViewJobs/Create
        public ActionResult Create()
        {
            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: ViewJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdJob,IdWho,User,DateAdd,ImageSRC,Titlu,WhereWhat,Description,Content,Solicitare,DateStart,DateEnd,Orar,Address,Latitudine,Longitudine,ZIP,Localitate,Region")] Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(jobs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email", jobs.User);
            return View(jobs);
        }

        // GET: ViewJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.Jobs.Find(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email", jobs.User);
            return View(jobs);
        }

        // POST: ViewJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdJob,IdWho,User,DateAdd,ImageSRC,Titlu,WhereWhat,Description,Content,Solicitare,DateStart,DateEnd,Orar,Address,Latitudine,Longitudine,ZIP,Localitate,Region")] Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User = new SelectList(db.AspNetUsers, "Id", "Email", jobs.User);
            return View(jobs);
        }

        // GET: ViewJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.Jobs.Find(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }

        // POST: ViewJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jobs jobs = db.Jobs.Find(id);
            db.Jobs.Remove(jobs);
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
