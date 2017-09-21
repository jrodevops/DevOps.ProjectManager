using DevOps.ProjectManager.Models;
using DevOps.ProjectManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevOps.ProjectManager.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel()
            {
                Projects = _context.Projects.OrderByDescending(p => p.DateCreated).Take(3),
                Issues = _context.Issues.OrderByDescending(i=>i.DateCreated).Take(3)
            };

            return View(viewModel);
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
    }
}