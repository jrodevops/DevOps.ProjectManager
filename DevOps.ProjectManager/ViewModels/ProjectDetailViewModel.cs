using DevOps.ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevOps.ProjectManager.ViewModels
{
    public class ProjectDetailViewModel
    {
        public Project Project { get; set; }

        public ProjectDetailViewModel(Project project)
        {
            Project = project;
        }
    }
}