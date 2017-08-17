using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            
            var connectionString =  DBConnectionConfiguration.GetConnectionStringByName("LocalJPaulik");
            Assert.AreEqual(connectionString,
                "Host=localhost; Port=5432; Username='postgres'; Password=3530744182a; Database=TrafficReportDB");
        }

        /// <summary>
        /// This method tests AddReport of <see cref="ReportRepository"/>
        /// </summary>
        [TestMethod]
        public void ReportRepositoryAddTest()
        {
            var repo = new ReportRepository();
            var report = new Report
            {
                Direction = Direction.E,
                Cause = Cause.crash,
                Lattitude = 50,
                Longitude = 50,

            };

            Assert.AreEqual(repo.AddReport(report), 1);

        }

        [TestMethod]
        public void ReportRepositoryRemoveByIdTest()
        {
            var id = new Guid("b814f246-ee8c-4e79-9f96-994d5cac90c9");
            var repo = new ReportRepository();

            Assert.AreEqual(1, repo.RemoveReport(id));
        }

        [TestMethod]
        public void ReportRepositoryGetByIdTest()
        {
            var id = new Guid("25d9f442-2c1d-4153-afce-894bb76417d0");
            var repo = new ReportRepository();

            var report = repo.GetReport(id);
        }

        //[TestMethod]
        //public void ReportServiceTest()
        //{
            
        //    var service = new ReportService();
        //    var report = new Report
        //    {
        //        Direction = Direction.E,
        //        Cause = Cause.crash,
        //        Lattitude = 50,
        //        Longitude = 50,

        //    };

        //    Assert.AreEqual(service.AddReport(report), true);

        //}
    }
}
