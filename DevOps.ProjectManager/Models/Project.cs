using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevOps.ProjectManager.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string Title {
            get
            {
                return Id > 0 ? "Edit project" : "New project" ;
            }
        }
    }
}