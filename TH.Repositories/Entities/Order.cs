using System;
using System.Collections.Generic;

namespace TH.Repositories.Entities
{
    public partial class Order
    {
        public string OrderId { get; set; }
        public string UserName { get; set; }
        public System.DateTime OrderTime { get; set; }
    
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
