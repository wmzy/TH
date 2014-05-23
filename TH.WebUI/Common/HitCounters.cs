using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Timers;
using System.Web;
using TH.Model;
using TH.Repositories;

namespace TH.WebUI.Common
{
    public class HitCounters
    {
        // 单个页面总访问量
        public static IDictionary<string, int> CountOfPage { get; private set; }
        // 网站总访问量
        public static int CountOfWebSite { get; private set; }
        // 当天访问量
        public static int CountOfToday { get; private set; }
        // 用户在线数量
        public static int CountOfUserOnline { get; private set; }

        public static void StartCount()
        {
            CountOfToday = 0;
            CountOfUserOnline = 0;

            using (var db = new THDbContext())
            {
                CountOfPage = db.PageHitCounterses.AsQueryable().ToDictionary(phc => phc.Url, phc => phc.Count);
            }
            CountOfWebSite = CountOfPage.Values.Sum();

            var timer = new Timer(Interval);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private static int Interval
        {
            get { return (24*3600 - DateTime.Now.Hour*3600 - DateTime.Now.Minute*60 - DateTime.Now.Second) * 1000; }
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CountOfToday = 0;
            ((Timer) sender).Interval = Interval;
        }

        internal static void SessionStart()
        {
            ++CountOfWebSite;
        }

        internal static void HitFor(string url)
        {
            if (CountOfPage.ContainsKey(url))
            {
                ++CountOfPage[url];
            }
            else
            {
                CountOfPage.Add(new KeyValuePair<string, int>(url, 1));
            }
        }

        internal static void SessionEnd()
        {
            --CountOfWebSite;
        }

        internal static void End()
        {
            using (var db = new THDbContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE PageHitCounterses");
                foreach (var cp in CountOfPage)
                {
                    db.PageHitCounterses.Add(new PageHitCounters {Url = cp.Key, Count = cp.Value});
                }
                db.SaveChanges();
            }
        }
    }
}