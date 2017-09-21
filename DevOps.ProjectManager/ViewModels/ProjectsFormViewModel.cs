using DevOps.ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevOps.ProjectManager.ViewModels
{
    public class ProjectsFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        public ProjectStatus Status { get; set; }

        public DateTime DateUpdate { get; set; }

        public DateTime DateCreated { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit project" : "New project";
            }
        }

        public IEnumerable<ProjectStatus> Statuses { get; set; }

        public ProjectsFormViewModel()
        {
            Id = 0;
        }

        public ProjectsFormViewModel(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Description = project.Description;
            StatusId = project.StatusId;
            DateUpdate = project.DateUpdated;
            DateCreated = project.DateCreated;
        }
    }
}