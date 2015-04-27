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
    public class JobSkillsController : Controller
    {
        private JobShopEntities db = new JobShopEntities();

        // GET: JobSkills
        public ActionResult Index()
        {
            var jobSkills = db.JobSkills.Include(j => j.Jobs);
            return View(jobSkills.ToList());
        }

        // GET: JobSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSkills jobSkills = db.JobSkills.Find(id);
            if (jobSkills == null)
            {
                return HttpNotFound();
            }
            return View(jobSkills);
        }

        // GET: JobSkills/Create
        public ActionResult Create()
        {
            ViewBag.Id_Job = new SelectList(db.Jobs, "IdJob", "User");
            return View();
        }

        // POST: JobSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSkill,Id_Job,Title,Level")] JobSkills jobSkills)
        {
            if (ModelState.IsValid)
            {
                db.JobSkills.Add(jobSkills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Job = new SelectList(db.Jobs, "IdJob", "User", jobSkills.Id_Job);
            return View(jobSkills);
        }

        // GET: JobSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSkills jobSkills = db.JobSkills.Find(id);
            if (jobSkills == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Job = new SelectList(db.Jobs, "IdJob", "User", jobSkills.Id_Job);
            return View(jobSkills);
        }

        // POST: JobSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSkill,Id_Job,Title,Level")] JobSkills jobSkills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSkills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Job = new SelectList(db.Jobs, "IdJob", "User", jobSkills.Id_Job);
            return View(jobSkills);
        }

        // GET: JobSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSkills jobSkills = db.JobSkills.Find(id);
            if (jobSkills == null)
            {
                return HttpNotFound();
            }
            return View(jobSkills);
        }

        // POST: JobSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobSkills jobSkills = db.JobSkills.Find(id);
            db.JobSkills.Remove(jobSkills);
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
