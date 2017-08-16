using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrafficReporter.Common
{
    /// <summary>
    /// This is only temporary soultion.
    /// Do not use it as long term solution.
    /// This is temporarly used until ConfigurationManager problem
    /// in <see cref="TrafficReporter.DAL.DBConnectionConfiguration"/> is resolved.
    /// </summary>
    public static class Constants
    {
        public static string LocalConnectionString =
            "Host=localhost; Port=5432; Username='postgres'; Password=3530744182a; Database=TrafficReportDB";
        public static string RemoteConnectionString =
            "Host=192.168.21.10; Port = 5432; Username='postgres'; Password=postgres; Database=trafficReport";
    }
}
