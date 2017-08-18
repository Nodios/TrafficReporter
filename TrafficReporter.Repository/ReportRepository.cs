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
        #region Properties

        protected IReportRepository Repository { get; private set; }

        #endregion Properties


        #region Constructors

        public ReportRepository(IReportRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Methods
        public async Task<int> AddReportAsync(IReport report)
        {
            var rowsAffrected = 0;

            using (var connection = new NpgsqlConnection(Constants.RemoteConnectionString))
            {
                await connection.OpenAsync();

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
                    rowsAffrected = await command.ExecuteNonQueryAsync();
                }
            }

            return rowsAffrected;
        }

        public async Task<IReport> GetReportAsync(Guid id)
        {
            IReport report = new Report();

            using (var connection = new NpgsqlConnection(Constants.RemoteConnectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand($"SELECT * FROM trafreport WHERE id = '{id}'", connection))
                using (var reader = await command.ExecuteReaderAsync())
                    while (reader.Read())
                    {
                        report = new Report();
                        report.Id = id;
                        report.Cause = (Cause) reader["cause"];
                        report.Rating = (int) reader["rating"];
                        report.Direction = (Direction) reader["direction"];
                        report.Longitude = (double) reader["longitude"];
                        report.Lattitude = (double) reader["lattitude"];
                        report.DateCreated = (DateTime) reader["date_created"];
                    }
            }

            return report;
        }

        public async Task<int> RemoveReportAsync(Guid id)
        {
            var rowsAffrected = 0;

            using (var connection = new NpgsqlConnection(Constants.RemoteConnectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText =
                        "DELETE FROM trafreport " +
                        $"WHERE id='{id}'";
                    rowsAffrected = await command.ExecuteNonQueryAsync();
                }
            }

            return rowsAffrected;
        }
        #endregion Method
    }

}
