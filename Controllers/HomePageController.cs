using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using JobShop.Models;

namespace JobShop.Controllers
{
    public class HomePageController : Controller
    {
        private JobShopEntities db = new JobShopEntities();

        /// <summary>
        /// Multiple Model in single view using Dynamic View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to my multi-model(s) test page!";
            dynamic mymodel = new ExpandoObject();
            mymodel.Jobs = GetJobs();
            mymodel.Candidates = GetCandidates();
            mymodel.AspNetUsers = GetUsers();
            return View(mymodel);
        }

        /// <summary>
        /// Multiple Model in single view using View Model
        /// </summary>
        /// <returns></returns>
        //public ActionResult IndexViewModel()
        //{
            //ViewBag.Message = "Welcome to my demo!";
            //HomePageModel mymodel = new HomePageModel();
            //mymodel.Jobs = GetJobs();
            //mymodel.Candidates = GetCandidates();
            //return View(mymodel);
        //}

        /// <summary>
        /// Multiple Model in single view using View Data
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexViewData()
        {
            ViewBag.Message = "Welcome to my demo!";
            ViewData["Jobs"] = GetJobs();
            ViewData["Candidates"] = GetCandidates();
            return View();
        }

        /// <summary>
        /// Multiple Model in single view using View Bag
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexViewBag()
        {
            ViewBag.Message = "Welcome to my demo!";
            ViewBag.Jobs = GetJobs();
            ViewBag.Candidates = GetCandidates();
            return View();
        }

        /// <summary>
        /// Multiple Model in single view using tuple
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexTuple()
        {
            ViewBag.Message = "Welcome to my demo!";
            var tupleModel = new Tuple<List<Jobs>, List<Candidates>>(GetJobs(), GetCandidates());
            return View(tupleModel);
        }

        /// <summary>
        /// Multiple Model in single view using Partial View
        /// </summary>
        /// <returns></returns>
        public ActionResult PartialView()
        {
            ViewBag.Message = "Welcome to my demo!";
            return View();
        }

        /// <summary>
        /// Render Job List
        /// </summary>
        /// <returns></returns>
        public PartialViewResult RenderJob()
        {
            return PartialView(GetJobs());
        }

        /// <summary>
        /// Render Candidate List
        /// </summary>
        /// <returns></returns>
        public PartialViewResult RenderCandidate()
        {
            return PartialView(GetCandidates());
        }

        public List<Jobs> GetJobs()
        {
            List<Jobs> Jobs = new List<Jobs>();
            var jobs = db.Jobs.Include(j => j.AspNetUsers);
            return jobs.ToList();
        }

        public List<Candidates> GetCandidates()
        {
            List<Candidates> Candidates = new List<Candidates>();
            var candidates = db.Candidates.Include(c => c.AspNetUsers);
            return candidates.ToList();
        }

        public List<AspNetUsers> GetUsers()
        {
            List<AspNetUsers> AspNetUsers = new List<AspNetUsers>();

            var aspnetusers = db.AspNetUsers;
            return aspnetusers.ToList();
        }
    }
}