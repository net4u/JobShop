using JobShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace JobShop
{
    public class JobRequirementsController : Controller
    {
        private JobShopEntities db = new JobShopEntities();

        // GET: JobRequirements
        public ActionResult Index()
        {
            var jobRequirements = db.JobRequirements.Include(j => j.Jobs);
            return View(jobRequirements.ToList());
        }

        // GET: JobRequirements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRequirements jobRequirements = db.JobRequirements.Find(id);
            if (jobRequirements == null)
            {
                return HttpNotFound();
            }
            return View(jobRequirements);
        }

        // GET: JobRequirements/Create
        public ActionResult Create()
        {
            ViewBag.Id_Job = new SelectList(db.Jobs, "IdJob", "User");
            return View();
        }

        // POST: JobRequirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReq,Id_Job,Requirement")] JobRequirements jobRequirements)
        {
            if (ModelState.IsValid)
            {
                db.JobRequirements.Add(jobRequirements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Job = new SelectList(db.Jobs, "IdJob", "User", jobRequirements.Id_Job);
            return View(jobRequirements);
        }

        // GET: JobRequirements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRequirements jobRequirements = db.JobRequirements.Find(id);
            if (jobRequirements == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Job = new SelectList(db.Jobs, "IdJob", "User", jobRequirements.Id_Job);
            return View(jobRequirements);
        }

        // POST: JobRequirements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReq,Id_Job,Requirement")] JobRequirements jobRequirements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobRequirements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Job = new SelectList(db.Jobs, "IdJob", "User", jobRequirements.Id_Job);
            return View(jobRequirements);
        }

        // GET: JobRequirements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRequirements jobRequirements = db.JobRequirements.Find(id);
            if (jobRequirements == null)
            {
                return HttpNotFound();
            }
            return View(jobRequirements);
        }

        // POST: JobRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobRequirements jobRequirements = db.JobRequirements.Find(id);
            db.JobRequirements.Remove(jobRequirements);
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
