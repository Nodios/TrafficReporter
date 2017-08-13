using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TrafficReporter.DAL
{
    /// <summary>
    /// This class helps contribute to "factory" design pattern,
    /// so our code doesn't depend on database provider.
    /// See this link for more information.
    /// https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/factory-model-overview
    /// </summary>
    public class DBConnectionConfiguration
    {

        public static string GetConnectionStringByProvider(string providerName)
        {
            string returnValue = null;

            var settings = ConfigurationManager.ConnectionStrings;

            if (settings != null)
            {
                foreach (ConnectionStringSettings connectionSetting in settings)
                {
                    if (connectionSetting.ProviderName.Equals(providerName))
                    {
                        returnValue = connectionSetting.ConnectionString;
                        break;
                    }
                }
            }

            return returnValue;
        }
    }
}
