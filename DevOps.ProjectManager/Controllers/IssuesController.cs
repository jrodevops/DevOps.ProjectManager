﻿using AutoMapper;
using DevOps.ProjectManager.DTO;
using DevOps.ProjectManager.Models;
using DevOps.ProjectManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevOps.ProjectManager.Controllers
{
    public class IssuesController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        public IssuesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Issues
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = RoleName.CanManageIssues)]
        public ActionResult New()
        {
            IssuesFormViewModel viewModel = new IssuesFormViewModel
            {
                Priorities = _context.Priorities.ToList(),
                Projects = _context.Projects.ToList()
            };
            return View("IssuesForm", viewModel);
        }

        [Route("/issues/edit/{id}")]
        [Authorize(Roles = RoleName.CanManageIssues)]
        public ActionResult Edit(int id)
        {
            Issue issueInDb = _context.Issues.SingleOrDefault(i => i.Id == id);
            if(issueInDb == null)
            {
                return HttpNotFound();
            }

            IssuesFormViewModel viewModel = new IssuesFormViewModel(issueInDb)
            {
                Priorities = _context.Priorities.ToList(),
                Projects = _context.Projects.ToList()
            };

            return View("IssuesForm", viewModel);
        }

        [Route("/issues/details/{id}")]
        public ActionResult Details(int id)
        {
            Issue issue = _context.Issues.Include(i => i.Project).Include(i => i.Priority).SingleOrDefault(i => i.Id == id);
            if (issue == null)
            {
                return HttpNotFound("Issue not found");
            }
            return View("Details", issue);
        }

        [Route("/issues/details/{id}")]
        public ActionResult DetailsExt(int id)
        {
            Issue issue = _context.Issues.Include(i => i.Project).Include(i => i.Priority).SingleOrDefault(i => i.Id == id);
            if(issue == null)
            {
                return HttpNotFound("Issue not found");
            }
            return PartialView("DetailsExt", issue);
        }

        [Authorize(Roles = RoleName.CanManageIssues)]
        public ActionResult Save(Issue issue)
        {
            if(!ModelState.IsValid)
            {
                IssuesFormViewModel viewModel = new IssuesFormViewModel
                {
                    Projects = _context.Projects.ToList(),
                    Priorities = _context.Priorities.ToList()
                };
            }
            ApplicationUser user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound("User not found");
            }

            if (issue.Id == 0)
            {
                issue.DateCreated = DateTime.Now;
                issue.DateUpdated = DateTime.Now;
                issue.CreatedById = user.Id;
                issue.CreatedBy = user;
                issue.UpdatedById = user.Id;
                issue.UpdatedBy = user;

                _context.Issues.Add(issue);
            }
            else
            {
                Issue issueInDb = _context.Issues.SingleOrDefault(i=>i.Id == issue.Id);
                if (issueInDb == null)
                {
                    return HttpNotFound("Issue not found");
                }

                issueInDb.Name = issue.Name;
                issueInDb.Description = issue.Description;
                issueInDb.PriorityId = issue.PriorityId;
                issueInDb.ProjectId = issue.ProjectId;
                issueInDb.DateUpdated = DateTime.Now;
                issueInDb.UpdatedById = user.Id;
                issueInDb.UpdatedBy = user;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Issues");
        }
    }
}