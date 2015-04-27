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

namespace JobShop.Controllers
{
    public class HomeController : Controller
    {
        //Old implementation
        //public ActionResult Index()
        //new implementation
        private JobShopEntities db = new JobShopEntities();
        //Repository _repository = new Repository(); 

        public ActionResult ViewModel()
        {
            HomePageModel vm = new HomePageModel();
            var jobs = db.Jobs.Include(j => j.AspNetUsers);
            var candidates = db.Candidates.Include(j => j.AspNetUsers);
            vm.allJobs = jobs.ToList();
            //vm.allJobs = _repository.GetCourses();
            vm.allCandidates = candidates.ToList();
            //vm.allUsers = _repository.GetStudents();

            return View(vm);
        }  



        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //New implementation
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
            var jobs = db.Jobs.Include(j => j.AspNetUsers);
            //Some search stuff
            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.Titlu.Contains(searchString)
                                       || s.Description.Contains(searchString));
            }
            //
            switch (sortOrder)
            {
                case "name_desc":
                    jobs = jobs.OrderByDescending(s => s.Titlu);
                    break;
                case "Date":
                    jobs = jobs.OrderBy(s => s.DateAdd);
                    break;
                case "date_desc":
                    jobs = jobs.OrderByDescending(s => s.DateAdd);
                    break;
                default:
                    //jobs = jobs.OrderBy(s => s.Titlu);
                    jobs = jobs.OrderBy(s => s.DateAdd);
                    break;
            }
            //
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(jobs.ToPagedList(pageNumber, pageSize));
            //return View(jobs.ToList());
            //Old plain simple impelementation
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Jobs()
        {
            ViewBag.Message = "Jobs page";

            return View();
        }

        public ActionResult Candidates()
        {
            ViewBag.Message = "Candidates page";

            return View();
        }
    }
}