using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Common;
using TrafficReporter.Model.Common;
using TrafficReporter.Repository.Common;
using Npgsql;

namespace TrafficReporter.Repository
{
    /// <summary>
    /// This class contains implemented methods for accesing database and
    /// querying trough it.
    /// </summary>
    public class ReportRepository : IReportRepository
    {
        public int AddReport(IReport report)
        {
            var rowsAffrected = 0;

            using (var connection = new NpgsqlConnection(Constants.RemoteConnectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO trafreport (id, cause, direction, longitude, lattitude, date_time)" +
                                          "VALUES (@id, @cause, @direction, @longitude, @lattitude, @date_time)";
                    command.Parameters.AddWithValue("id", Guid.NewGuid());
                    command.Parameters.AddWithValue("cause", (int)report.Cause);
                    command.Parameters.AddWithValue("direction", (int)report.Direction);
                    command.Parameters.AddWithValue("longitude", report.Longitude);
                    command.Parameters.AddWithValue("lattitude", report.Lattitude);
                    command.Parameters.AddWithValue("date_time", DateTime.Now);
                    rowsAffrected = command.ExecuteNonQuery();
                }
            }

            return rowsAffrected;
        }



        public IReport GetReport(Guid id)
        {
            IReport report = null;

            using (var connection = new NpgsqlConnection(Constants.RemoteConnectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM trafreport", connection))
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine(reader.GetString(0), reader.GetString(1));
            }


            return report;
        }

        public bool RemoveReport(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
