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
    public class CandidateReqsController : Controller
    {
        private JobShopEntities db = new JobShopEntities();

        // GET: CandidateReqs
        public async Task<ActionResult> Index()
        {
            var candidateReq = db.CandidateReq.Include(c => c.Candidates);
            return View(await candidateReq.ToListAsync());
        }

        // GET: CandidateReqs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateReq candidateReq = await db.CandidateReq.FindAsync(id);
            if (candidateReq == null)
            {
                return HttpNotFound();
            }
            return View(candidateReq);
        }

        // GET: CandidateReqs/Create
        public ActionResult Create()
        {
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User");
            return View();
        }

        // POST: CandidateReqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdReq,Id_CV,Requirement")] CandidateReq candidateReq)
        {
            if (ModelState.IsValid)
            {
                db.CandidateReq.Add(candidateReq);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateReq.Id_CV);
            return View(candidateReq);
        }

        // GET: CandidateReqs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateReq candidateReq = await db.CandidateReq.FindAsync(id);
            if (candidateReq == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateReq.Id_CV);
            return View(candidateReq);
        }

        // POST: CandidateReqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdReq,Id_CV,Requirement")] CandidateReq candidateReq)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateReq).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id_CV = new SelectList(db.Candidates, "IdCV", "User", candidateReq.Id_CV);
            return View(candidateReq);
        }

        // GET: CandidateReqs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateReq candidateReq = await db.CandidateReq.FindAsync(id);
            if (candidateReq == null)
            {
                return HttpNotFound();
            }
            return View(candidateReq);
        }

        // POST: CandidateReqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CandidateReq candidateReq = await db.CandidateReq.FindAsync(id);
            db.CandidateReq.Remove(candidateReq);
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
