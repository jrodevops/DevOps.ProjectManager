using DevOps.ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevOps.ProjectManager.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Issue> Issues { get; set; }

        public HomeViewModel()
        {

        }
    }
}