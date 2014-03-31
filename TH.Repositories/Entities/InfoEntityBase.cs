using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.Repositories.Entities
{
    public abstract class InfoEntityBase
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int GenreId { get; set; }
    }
}
