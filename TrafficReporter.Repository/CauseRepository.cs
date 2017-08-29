using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using TrafficReporter.Common;
using TrafficReporter.Common.Enums;
using TrafficReporter.Model;
using TrafficReporter.Model.Common;
using TrafficReporter.Repository.Common;
using TrafficReporter.Service.Common;
using Cause = TrafficReporter.Model.Cause;

namespace TrafficReporter.Repository
{
    class CauseRepository : ICauseRepository
    {
        public CauseRepository()
        {
            
        }

        public async Task<IEnumerable<ICause>> GetCausesAsync()
        {
            List<ICause> causes = new List<ICause>();

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RemoteDB"]
                .ConnectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand("SELECT id, cause_str, icon_uri FROM cause_table", connection))
                {
                   
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var cause = new Cause();
                            cause.Id = (int) reader.GetDataSafely("id");
                            cause.IconUri = reader.GetDataSafely("icon_uri").ToString();
                            cause.Name = reader.GetDataSafely("cause_str").ToString();
                            causes.Add(cause);
                        }

                        reader.Close();
                    }
                }
                connection.Close();
            }

            return causes;
        }
    }
}
