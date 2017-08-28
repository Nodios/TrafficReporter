using TrafficReporter.DAL;
using TrafficReporter.Model;
using TrafficReporter.Model.Common;
using TrafficReporter.Repository.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using TrafficReporter.Common;
using TrafficReporter.Common.Enums;
using TrafficReporter.Common.Filter;
using TrafficReporter.DAL.Entity_Models;

namespace TrafficReporter.Repository
{
    /// <summary>
    /// This class contains implemented methods for accesing database and
    /// querying trough it.
    /// </summary>
    public class ReportRepository : IReportRepository
    {
        #region Constructors

        public ReportRepository()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds the report to database.
        /// </summary>
        /// <param name="report">The report to be added to database.</param>
        /// <returns>
        /// Number of rows affected by removing(should be 1).
        /// </returns>
        public async Task<int> AddReportAsync(IReport report)
        {
            var rowsAffrected = 0;

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RemoteDB"]
                .ConnectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText =
                        "INSERT INTO trafreport (id, cause, direction, longitude, lattitude, date_created)" +
                        "VALUES (@id, @cause, @direction, @longitude, @lattitude, @date_created)";
                    command.Parameters.AddWithValue("id", report.Id);
                    command.Parameters.AddWithValue("cause", report.Cause);
                    command.Parameters.AddWithValue("direction", (int) report.Direction);
                    command.Parameters.AddWithValue("longitude", report.Longitude);
                    command.Parameters.AddWithValue("lattitude", report.Lattitude);
                    //todo do not use datetime.now here, get time from frontend
                    command.Parameters.AddWithValue("date_created", DateTime.Now);
                    rowsAffrected = await command.ExecuteNonQueryAsync();
                }
            }

            return rowsAffrected;
        }

        public async Task<IReport> GetReportAsync(Guid id)
        {
            IReport report = null;


            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RemoteDB"]
                .ConnectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand($"SELECT * FROM trafreport WHERE id = '{id}'", connection))
                using (var reader = await command.ExecuteReaderAsync())
                    while (reader.Read())
                    {
                        report = new Report();
                        report.Id = id;
                        report.Cause = (int) reader.GetDataSafely("cause");
                        report.Rating = (int) reader.GetDataSafely("rating");
                        report.Direction = (Direction) reader.GetDataSafely("direction");
                        report.Longitude = (double) reader.GetDataSafely("longitude");
                        report.Lattitude = (double) reader.GetDataSafely("lattitude");
                        report.DateCreated = (DateTime) reader.GetDataSafely("date_created");
                    }
            }

            return report;
        }

        /// <summary>
        /// Gets all reports from database which satisfy passed filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>
        /// Collection of reports that satisfy filters.
        /// </returns>
        public async Task<IEnumerable<IReport>> GetFilteredReportsAsync(IFilter filter)
        {
            List<IReport> reports = new List<IReport>();

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RemoteDB"]
                .ConnectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    var commandText = new StringBuilder("SELECT * FROM trafreport ");

                    //If there is at least one filter, then apply
                    //WHERE part of the SQL query.
                    if (filter != null)
                    {
                        commandText.Append("WHERE ");

                        //This is filtering like here:
                        //https://timdams.com/2011/02/14/using-enum-flags-to-write-filters-in-linq/
                        if (filter.Cause != 0)
                        {
                            //I'm here adding AND  because coordinates must be specified or
                            //db could be outputting reports that might be out of the area
                            //of visible map.
                            commandText.Append($"cause & {filter.Cause} > 0 AND ");
                        }

                        
                        commandText.Append($"longitude BETWEEN {filter.LowerLeftX} AND {filter.UpperRightX} AND ");
                        commandText.Append($"lattitude BETWEEN {filter.LowerLeftY} AND {filter.UpperRightY}");

                        commandText.Append($"");

                        commandText.Append($"LIMIT {filter.PageSize}");

                    }
                    command.CommandText = commandText.ToString().Replace(',', '.');

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var report = new Report();
                            report.Id = (Guid) reader.GetDataSafely("id");
                            report.Cause = (int) reader.GetDataSafely("cause");
                            report.Rating = (int) reader.GetDataSafely("rating");
                            report.Direction = (Direction) reader.GetDataSafely("direction");
                            report.Longitude = (double) reader.GetDataSafely("longitude");
                            report.Lattitude = (double) reader.GetDataSafely("lattitude");
                            report.DateCreated = (DateTime) reader.GetDataSafely("date_created");
                            reports.Add(report);
                        }
                    }
                }
            }

            return reports;
        }

        /// <summary>
        /// Removes the report from database by passing Id parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Number of rows affected by removing(should be 1).
        /// </returns>
        //todo this method might be removed because we don't want anyone else but db to delete reports
        public async Task<int> RemoveReportAsync(Guid id)
        {
            var rowsAffrected = 0;

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RemoteDB"]
                .ConnectionString))
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

        #endregion Methods
    }
}