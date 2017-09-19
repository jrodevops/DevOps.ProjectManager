using AutoMapper;
using DevOps.ProjectManager.DTO;
using DevOps.ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevOps.ProjectManager.API
{
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/projects
        public IEnumerable<ProjectDto> GetProjects()
        {
            return _context.Projects.Include(p => p.Status).ToList().Select(AutoMapper.Mapper.Map<Project, ProjectDto>);
        }

        // PUT /api/projects/{id}
        [HttpPut]
        public void UpdateProject(int id, ProjectDto projectDto)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Project projectInDb = _context.Projects.SingleOrDefault(p => p.Id == id);
            if(projectInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(projectDto, projectInDb);
            _context.SaveChanges();
        }

        // DELETE /api/projects/{id}
        [HttpDelete]
        public void DeleteProject(int id)
        {
            Project project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Projects.Remove(project);
            _context.SaveChanges();

            RedirectToRoute("Index", "Projects");
        }
    }
}
