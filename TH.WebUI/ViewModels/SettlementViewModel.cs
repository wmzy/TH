using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class SettlementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ValidDate { get; set; }
        public int DelayDays { get; set; }
        public int WealthValue { get; set; }
    }
}