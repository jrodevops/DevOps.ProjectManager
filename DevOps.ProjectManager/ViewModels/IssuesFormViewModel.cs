using DevOps.ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevOps.ProjectManager.ViewModels
{
    public class IssuesFormViewModel
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }

        public Priority Priority { get; set; }

        [Required]
        [Display(Name="Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }
        
        //Collections
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Priority> Priorities { get; set; }

        public IssuesFormViewModel()
        {
            Id = 0;
        }

        public IssuesFormViewModel(Issue issue)
        {
            Name = issue.Name;
            Description = issue.Description;
            PriorityId = issue.PriorityId;
            ProjectId = issue.ProjectId;
        }
    }
}