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
        public async Task<int> AddReportAsync(IReport report)
        {
            var rowsAffrected = 0;

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RemoteDB"].ConnectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText =
                        "INSERT INTO trafreport (id, cause, direction, longitude, lattitude, date_created)" +
                        "VALUES (@id, @cause, @direction, @longitude, @lattitude, @date_created)";
                    command.Parameters.AddWithValue("id", Guid.NewGuid());
                    command.Parameters.AddWithValue("cause", (int) report.Cause);
                    command.Parameters.AddWithValue("direction", (int) report.Direction);
                    command.Parameters.AddWithValue("longitude", report.Longitude);
                    command.Parameters.AddWithValue("lattitude", report.Lattitude);
                    command.Parameters.AddWithValue("date_created", DateTime.Now);
                    rowsAffrected = await command.ExecuteNonQueryAsync();
                }
            }

            return rowsAffrected;
        }

        public async Task<IReport> GetReportAsync(Guid id)
        {


           
        IReport report = null;

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RemoteDB"].ConnectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand($"SELECT * FROM trafreport WHERE id = '{id}'", connection))
                using (var reader = await command.ExecuteReaderAsync())
                    while (reader.Read())
                    {
                        report = new Report();
                        report.Id = id;
                        report.Cause = (Cause)reader["cause"];                        
                        report.Rating = (int) reader["rating"];
                        report.Direction = (Direction) reader["direction"];
                        report.Longitude = (double) reader["longitude"];
                        report.Lattitude = (double) reader["lattitude"];
                        report.DateCreated = (DateTime) reader["date_created"];

                        

                    }
            }

            return report;
        }

        public async Task<IEnumerable<IReport>> GetFilteredReportsAsync(IFilter filter)
        {
            List<IReport> reports = new List<IReport>();

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RemoteDB"].ConnectionString))
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

                        if (filter != null)
                        {
                            commandText.Append($"cause = {(int) filter.Cause} ");
                            
                        }

                        if (filter != null)
                        {
                            //This adds AND keyword if there is at least one filter before this one.
                            if (filter != null)
                            {
                                commandText.Append("AND ");
                            }
                            commandText.Append($"longitude BETWEEN {filter.LowerLeftX} AND {filter.UpperRightX} AND ");
                            commandText.Append($"lattitude BETWEEN {filter.LowerLeftY} AND {filter.UpperRightY}");
                        }
                    }
                    command.CommandText = commandText.ToString();
                    
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var report = new Report();
                            report.Id = (Guid)reader["id"];
                            report.Cause = (Cause)reader["cause"];
                            report.Rating = (int)reader["rating"];
                            report.Direction = (Direction)reader["direction"];
                            report.Longitude = (double)reader["longitude"];
                            report.Lattitude = (double)reader["lattitude"];
                            report.DateCreated = (DateTime)reader["date_created"];
                            reports.Add(report);
                        }
                    }

                }
            }

            return reports;
        }

        public async Task<int> RemoveReportAsync(Guid id)
        {
            var rowsAffrected = 0;

            using (var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["RemoteDB"].ConnectionString))
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
