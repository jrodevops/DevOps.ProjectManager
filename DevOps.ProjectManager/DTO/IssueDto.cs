using DevOps.ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevOps.ProjectManager.DTO
{
    public class IssueDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        [Display(Name = "Created by")]
        public string CreatedById { get; set; }

        public ApplicationUser CreatedBy { get; set; }

        [Display(Name = "Updated by")]
        public string UpdatedById { get; set; }

        public ApplicationUser UpdatedBy { get; set; }


        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}