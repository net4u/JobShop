using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobShop;

namespace JobShop.Controllers
{
    public class CandidateExperiencesController : Controller
    {
        private JobShopEntities db = new JobShopEntities();

        // GET: CandidateExperiences
        public async Task<ActionResult> Index()
        {
            var candidateExperience = db.CandidateExperience.Include(c => c.Candidates);
            return View(await candidateExperience.ToListAsync());
        }

        // GET: CandidateExperiences/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateExperience candidateExperience = await db.CandidateExperience.FindAsync(id);
            if (candidateExperience == null)
            {
                return HttpNotFound();
            }
            return View(candidateExperience);
        }

        // GET: CandidateExperiences/Create
        public ActionResult Create()
        {
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User");
            return View();
        }

        // POST: CandidateExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdExp,Id_CV,Description,DateStart,DateEnd")] CandidateExperience candidateExperience)
        {
            if (ModelState.IsValid)
            {
                db.CandidateExperience.Add(candidateExperience);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateExperience.Id_CV);
            return View(candidateExperience);
        }

        // GET: CandidateExperiences/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateExperience candidateExperience = await db.CandidateExperience.FindAsync(id);
            if (candidateExperience == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateExperience.Id_CV);
            return View(candidateExperience);
        }

        // POST: CandidateExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdExp,Id_CV,Description,DateStart,DateEnd")] CandidateExperience candidateExperience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateExperience).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateExperience.Id_CV);
            return View(candidateExperience);
        }

        // GET: CandidateExperiences/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateExperience candidateExperience = await db.CandidateExperience.FindAsync(id);
            if (candidateExperience == null)
            {
                return HttpNotFound();
            }
            return View(candidateExperience);
        }

        // POST: CandidateExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CandidateExperience candidateExperience = await db.CandidateExperience.FindAsync(id);
            db.CandidateExperience.Remove(candidateExperience);
            await db.SaveChangesAsync();
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
