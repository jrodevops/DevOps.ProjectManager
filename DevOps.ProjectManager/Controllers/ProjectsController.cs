﻿using DevOps.ProjectManager.Models;
using DevOps.ProjectManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevOps.ProjectManager.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Projects
        public ActionResult Index()
        {
            IEnumerable<Project> projects = _context.Projects.Include(p => p.Status).ToList();
            return View(projects);
        }

        //[Route("/projects/details/{id}")]
        //public ActionResult Details(int id)
        //{
        //    Project projectInDb = _context.Projects.SingleOrDefault(p => p.Id == id);
        //    if(projectInDb == null)
        //    {
        //        return HttpNotFound("Project not found");
        //    }

        //    return View(projectInDb);
        //}

        [Route("/projects/details/{id}")]
        [Route("/projects/details/{id}", Name = "DetailsExt")]
        public ActionResult Details(int id)
        {
            Project projectInDb = _context.Projects.Include(p=>p.Status).SingleOrDefault(p => p.Id == id);
            if (projectInDb == null)
            {
                return HttpNotFound("Project not found");
            }

            return PartialView("DetailsExt", projectInDb);
        }


        public ActionResult New()
        {
            ProjectsFormViewModel viewModel = new ProjectsFormViewModel
            {
                Statuses = _context.ProjectStatuses.ToList()
            };
            return View("ProjectsForm", viewModel);
        }

        [Route("/projects/edit/{id}")]
        public ActionResult Edit(int id)
        {
            Project project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if(project == null)
            {
                return HttpNotFound("Project not found");
            }

            ProjectsFormViewModel viewModel = new ProjectsFormViewModel(project)
            {
                Statuses = _context.ProjectStatuses.ToList()
            };

            return View("ProjectsForm", viewModel);
        }

        public void Delete(int id)
        {
            Project project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if(project == null)
            {
                throw new HttpException("Project not found");
            }

            _context.Projects.Remove(project);
            _context.SaveChanges();

            //return View("Index");
        }

        public ActionResult Save(Project project)
        {
            if(!ModelState.IsValid)
            {
                ProjectsFormViewModel viewModel = new ProjectsFormViewModel
                {
                    Statuses = _context.ProjectStatuses.ToList()
                };
            }

            if(project.Id == 0)
            {
                project.DateUpdated = DateTime.Now;
                project.DateCreated = DateTime.Now;

                _context.Projects.Add(project);
            }
            else
            {
                Project projectInDb = _context.Projects.SingleOrDefault(p => p.Id == project.Id);
                if (projectInDb == null)
                {
                    return HttpNotFound("Project not found");
                }

                projectInDb.Name = project.Name;
                projectInDb.Description = project.Description;
                projectInDb.Status = project.Status;
                projectInDb.DateUpdated = DateTime.Now;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }
    }
}