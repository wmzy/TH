using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TH.Repositories.Entities
{
    [Table("Region")]
    public class Region
    {
        public int RegionId { set; get; }
        public string RegionName { get; set; }
    }
}
