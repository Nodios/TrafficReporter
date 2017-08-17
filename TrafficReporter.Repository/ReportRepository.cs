using TrafficReporter.DAL;
using TrafficReporter.Model;
using TrafficReporter.Model.Common;
using TrafficReporter.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using TrafficReporter.Common;
using TrafficReporter.Common.Enums;


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
                    command.CommandText =
                        "INSERT INTO trafreport (id, cause, direction, longitude, lattitude, date_time)" +
                        "VALUES (@id, @cause, @direction, @longitude, @lattitude, @date_time)";
                    command.Parameters.AddWithValue("id", Guid.NewGuid());
                    command.Parameters.AddWithValue("cause", (int) report.Cause);
                    command.Parameters.AddWithValue("direction", (int) report.Direction);
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
            IReport report = new Report();

            using (var connection = new NpgsqlConnection(Constants.LocalConnectionString))
            {
                using (var command = new NpgsqlCommand(String.Format("SELECT * FROM report WHERE id = '{0}'", id)))
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        report.Id = id;
                        report.Cause = (Cause) reader[1];
                        report.Rating = (int) reader[2];
                        report.Direction = (Direction) reader[3];
                        report.Longitude = (double) reader[4];
                        report.Lattitude = (double) reader[5];
                        report.DateCreated = (DateTime) reader[6];
                    }
            }

            return report;
        }

        public bool RemoveReport(Guid id)
        {
            throw new NotImplementedException();
        }
    }

}
