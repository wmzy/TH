using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TH.Repositories.Entities;

namespace TH.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
    }
}