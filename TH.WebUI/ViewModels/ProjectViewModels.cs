using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class ProjectIndexViewModel
    {
    }
    public class ProjectCreateViewModel
    {
        public string Title { get; set; }

        public string Company { get; set; }

        public string ContactPerson { get; set; }

        public string Telephones { get; set; }
    }
    public class ProjectDetailsViewModel
    {
        public string Company { get; set; }

        public string Telephones { get; set; }

        public string Title { get; set; }

        public int TimeLimit { get; set; }

        public DateTime? StartTime { get; set; }

        public string Require { get; set; }

        public string ProjectName { get; set; }

        public string ContactPerson { get; set; }

        public string City { get; set; }
    }

    public class ProjectEditViewModel
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public string City { get; set; }

        public string ContactPerson { get; set; }

        public string ProjectName { get; set; }

        public string Require { get; set; }

        public DateTime? StartTime { get; set; }

        public int TimeLimit { get; set; }

        public DateTime? ValidDate { get; set; }

        public string Telephones { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}