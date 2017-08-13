using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficReporter.DAL;

namespace TrafficReporter.UnitTest
{
    [TestClass]
    public class DbConnectionStringTest
    {
        /// <summary>
        /// I tested GetConnectionStringByProvider() method for my
        /// <see cref="DBConnectionConfiguration"/> class.
        /// In config file, we should put new connection string for remote computer.
        /// </summary>
        [TestMethod]
        public void GetConnectionStringByProviderTest()
        {
           
            var connectionString = DBConnectionConfiguration.GetConnectionStringByProvider("Npgsql");
            Assert.AreEqual(connectionString,
                "Host=localhost; Port=5432; Username='postgres'; Password=3530744182a; Database=TrafficReportDB");
        }
    }
}
