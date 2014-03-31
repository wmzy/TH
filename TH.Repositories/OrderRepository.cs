using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TH.Repositories.Entities;
//using Microsoft.Practices.Unity.Utility;

namespace TH.Repositories
{
    public class OrderRepository : THRepository<Order>, IOrderRepository
    {
        public OrderRepository(THDbContext dbContext)
            : base(dbContext)
        { }

        public void AddOrder(Order order)
        {
            //Guard.ArgumentNotNull(order, "order");
            this.Add(order);
        }
    }
}