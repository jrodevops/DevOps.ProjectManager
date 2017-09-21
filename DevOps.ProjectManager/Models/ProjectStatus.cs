using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevOps.ProjectManager.Models
{
    public class ProjectStatus
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }

    public class ProjectStatusId
    {
        public const int Open = 1;
        public const int Closed = 2;
        public const int Current = 3;
        public const int Onhold = 4;
        public const int Archived = 5;
        public const int Planning = 6;
        public const int Requested = 7;
        public const int Approved = 8;
        public const int Declined = 9;
        public const int Idea = 10;
    }
}