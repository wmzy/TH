using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TH.Repositories.Entities;

namespace TH.Services
{
    public interface IOrderService
    {
        void SubmitOrder(Order order);
    }
}
