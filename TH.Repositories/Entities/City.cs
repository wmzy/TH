using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TH.Repositories.Entities
{
    [Table("City")]
    public class City
    {
        public int CityId { set; get; }
        public string CityName { get; set; }
    }
}
