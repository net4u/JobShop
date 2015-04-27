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
    public class CandidateEducationsController : Controller
    {
        private JobShopEntities db = new JobShopEntities();

        // GET: CandidateEducations
        public async Task<ActionResult> Index()
        {
            var candidateEducation = db.CandidateEducation.Include(c => c.Candidates);
            return View(await candidateEducation.ToListAsync());
        }

        // GET: CandidateEducations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateEducation candidateEducation = await db.CandidateEducation.FindAsync(id);
            if (candidateEducation == null)
            {
                return HttpNotFound();
            }
            return View(candidateEducation);
        }

        // GET: CandidateEducations/Create
        public ActionResult Create()
        {
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User");
            return View();
        }

        // POST: CandidateEducations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Edu,Id_CV,Description,DateStart,DateEnd")] CandidateEducation candidateEducation)
        {
            if (ModelState.IsValid)
            {
                db.CandidateEducation.Add(candidateEducation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateEducation.Id_CV);
            return View(candidateEducation);
        }

        // GET: CandidateEducations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateEducation candidateEducation = await db.CandidateEducation.FindAsync(id);
            if (candidateEducation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateEducation.Id_CV);
            return View(candidateEducation);
        }

        // POST: CandidateEducations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Edu,Id_CV,Description,DateStart,DateEnd")] CandidateEducation candidateEducation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateEducation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateEducation.Id_CV);
            return View(candidateEducation);
        }

        // GET: CandidateEducations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateEducation candidateEducation = await db.CandidateEducation.FindAsync(id);
            if (candidateEducation == null)
            {
                return HttpNotFound();
            }
            return View(candidateEducation);
        }

        // POST: CandidateEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CandidateEducation candidateEducation = await db.CandidateEducation.FindAsync(id);
            db.CandidateEducation.Remove(candidateEducation);
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
