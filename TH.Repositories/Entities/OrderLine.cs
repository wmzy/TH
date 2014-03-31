using System;
using System.Collections.Generic;

namespace TH.Repositories.Entities
{
    public partial class OrderLine
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
    
}
