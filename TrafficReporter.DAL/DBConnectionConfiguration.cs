using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TrafficReporter.DAL
{
    /// <summary>
    /// This class helps to get connection string easily only by name.
    /// </summary>
    public class DBConnectionConfiguration
    {

        /// <summary>
        /// Gets connection string to database.
        /// This way it is easy to switch from database to another one.
        /// </summary>
        /// <param name="name">Name we given for our connection string in config file</param>
        /// <returns></returns>
        public static string GetConnectionStringByName(string name)
        {
            string connectionString = null;

            ConfigurationManager.RefreshSection("connectionStrings");
            var connectionStrings = ConfigurationManager.ConnectionStrings;

            foreach (ConnectionStringSettings connectionSetting in connectionStrings)
            {
                if (connectionSetting.Name.Equals(name))
                {
                    connectionString = connectionSetting.ConnectionString;

                }
            }

            return connectionString;
        }
    }
}
