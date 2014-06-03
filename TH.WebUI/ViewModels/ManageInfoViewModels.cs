using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class InfoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ValidDate { get; set; }
    }

    public class InfosViewModel
    {
        public IEnumerable<InfoViewModel> Infos { get; set; }
        public string Genre { get; set; }
        public string ControllerName { get; set; }
    }
}