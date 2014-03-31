using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Repositories;
using TH.Repositories.Entities;

namespace TH.Services
{
    public class FullTimeJobService : ServiceBase, IJobService, IDisposable
    {
        readonly IJobRepository fullTimeJobRepository;
        //public FullTimeJobService(IJobRepository fullTimeJobRepository)
        //{
        //    this.fullTimeJobRepository = fullTimeJobRepository;
        //}
    }
}
