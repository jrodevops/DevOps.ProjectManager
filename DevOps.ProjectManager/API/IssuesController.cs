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
    public class IssuesController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public IssuesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/issues
        public IEnumerable<IssueDto> GetIssues()
        {
            return _context.Issues.Include(p => p.UpdatedBy).Include(p => p.CreatedBy).Include(p=>p.Priority).Include(p => p.Project).ToList().Select(AutoMapper.Mapper.Map<Issue, IssueDto>);
        }

        // GET /api/issues/{Id}
        public IEnumerable<IssueDto> GetIssues(int id)
        {
            return _context.Issues.Where(i=>i.ProjectId == id).Include(p => p.Priority).Include(p => p.Project).ToList().Select(AutoMapper.Mapper.Map<Issue, IssueDto>);
        }


        // PUT /api/issues/{id}
        [HttpPut]
        public void UpdateIssue(int id, IssueDto issueDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Issue issueInDb = _context.Issues.SingleOrDefault(p => p.Id == id);
            if (issueInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(issueDto, issueInDb);
            _context.SaveChanges();
        }

        // DELETE /api/issues/{id}
        [HttpDelete]
        public void DeleteIssue(int id)
        {
            Issue issueInDb = _context.Issues.SingleOrDefault(p => p.Id == id);
            if (issueInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Issues.Remove(issueInDb);
            _context.SaveChanges();

            RedirectToRoute("Index", "Issues");
        }
    }
}
