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
        public string Genre { get; set; }

        public DateTime? CreateDate { get; set; }

        public string ControllerName { get; set; }
    }
}