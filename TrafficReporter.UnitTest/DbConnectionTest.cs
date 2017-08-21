using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficReporter.Common;
using TrafficReporter.DAL;
using TrafficReporter.Model;
using TrafficReporter.Repository;
using TrafficReporter.Repository.Common;
using TrafficReporter.Common.Enums;
using TrafficReporter.Service;

namespace TrafficReporter.UnitTest
{
    /// <summary>
    /// This class contains test methods which test database functionailty
    /// </summary>
    [TestClass]
    public class DbConnectionTest
    {
        /// <summary>
        /// I tested GetConnectionStringByName() method for my
        /// <see cref="DBConnectionConfiguration"/> class.
        /// In config file, we should put new connection string for remote computer.
        /// </summary>
        [TestMethod]
        public void GetConnectionStringByNameTest()
        {

            var connectionString = DBConnectionConfiguration.GetConnectionStringByName("LocalJPaulik");
            Assert.AreEqual(connectionString,
                "Host=localhost; Port=5432; Username='postgres'; Password=3530744182a; Database=TrafficReportDB");
        }

        /// <summary>
        /// This method tests AddReport of <see cref="ReportRepository"/>
        /// </summary>
        [TestMethod]
        public async Task ReportRepositoryAddTest()
        {
            var repo = new ReportRepository();
            var report = new Report
            {
                Direction = Direction.E,
                Cause = Cause.crash,
                Lattitude = 50,
                Longitude = 50,

            };

            Assert.AreEqual(await repo.AddReportAsync(report), 1);

        }

        [TestMethod]
        public async Task ReportRepositoryGetByIdTest()
        {
            var id = new Guid("ff207340-f838-4245-8a20-4b3b92aab3c1");
            var repo = new ReportRepository();

            var report = await repo.GetReportAsync(id);

           
        }

        [TestMethod]
        public async Task ReportRepositoryFilterTest()
        {
            var filter = new CauseFilter(0, 5, 5);
            var repo = new ReportRepository();

            var reports = await repo.GetFilteredReportsAsync(filter);
        }
    }
}
