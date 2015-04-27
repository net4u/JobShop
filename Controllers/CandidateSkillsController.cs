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
    public class CandidateSkillsController : Controller
    {
        private JobShopEntities db = new JobShopEntities();

        // GET: CandidateSkills
        public async Task<ActionResult> Index()
        {
            var candidateSkills = db.CandidateSkills.Include(c => c.Candidates);
            return View(await candidateSkills.ToListAsync());
        }

        // GET: CandidateSkills/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateSkills candidateSkills = await db.CandidateSkills.FindAsync(id);
            if (candidateSkills == null)
            {
                return HttpNotFound();
            }
            return View(candidateSkills);
        }

        // GET: CandidateSkills/Create
        public ActionResult Create()
        {
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User");
            return View();
        }

        // POST: CandidateSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Skill,Id_CV,Title,Level,Description")] CandidateSkills candidateSkills)
        {
            if (ModelState.IsValid)
            {
                db.CandidateSkills.Add(candidateSkills);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateSkills.Id_CV);
            return View(candidateSkills);
        }

        // GET: CandidateSkills/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateSkills candidateSkills = await db.CandidateSkills.FindAsync(id);
            if (candidateSkills == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateSkills.Id_CV);
            return View(candidateSkills);
        }

        // POST: CandidateSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Skill,Id_CV,Title,Level,Description")] CandidateSkills candidateSkills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateSkills).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateSkills.Id_CV);
            return View(candidateSkills);
        }

        // GET: CandidateSkills/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateSkills candidateSkills = await db.CandidateSkills.FindAsync(id);
            if (candidateSkills == null)
            {
                return HttpNotFound();
            }
            return View(candidateSkills);
        }

        // POST: CandidateSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CandidateSkills candidateSkills = await db.CandidateSkills.FindAsync(id);
            db.CandidateSkills.Remove(candidateSkills);
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
