using System;
using System.Data.Entity;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TH.Model;
using TH.Repositories;

namespace TH.Test
{
    [TestClass]
    public class TestTHDbContext
    {
        private readonly THDbContext _dbContext;

        public TestTHDbContext()
        {
            _dbContext = new THDbContext();
        }
        [ClassInitialize]
        public static void ClassSetup(TestContext a)
        {
        }
        [TestMethod]
        public void TestMethod1()
        {
            DbSet<Job> jobs = _dbContext.GetType().GetProperty("Jobs").GetValue(_dbContext) as DbSet<Job>;
            Debug.Assert(jobs == _dbContext.Jobs);
        }
    }
}
