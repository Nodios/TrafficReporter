using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Common;
using TrafficReporter.Model.Common;
using TrafficReporter.Repository.Common;
using Npgsql;
using TrafficReporter.DAL.Entity_Models;
using TrafficReporter.Common.Enums;

namespace TrafficReporter.Repository
{
    public class ReportRepository : IReportRepository
    {
        private IPostgresConnection Connection { get; set; }

        public ReportRepository(IPostgresConnection connection)
        {
            this.Connection = connection;
        }

        public bool AddReport(IReportPOCO report)
        {
            Report NewReport = null;
            bool IsCreated = false;
            using (var conn = Connection.GetConnection())
            using (NpgsqlCommand commandInsert = new NpgsqlCommand("insert into report(id, cause, time_, longitude, latitude, rating, direction, ban) VALUES (@id, @cause, @time_, @longitude, @latitude, @rating, @direction, @ban);", conn))
            using (NpgsqlCommand commandSelect = new NpgsqlCommand("select * from report where report.Id = @id", conn))
            {
                conn.Open();

                commandInsert.Parameters.AddWithValue("@id", NpgsqlTypes.NpgsqlDbType.Uuid, report.Id);
                commandInsert.Parameters.AddWithValue("@cause", NpgsqlTypes.NpgsqlDbType.Integer, Convert.ToInt32(report.Cause));
                commandInsert.Parameters.AddWithValue("@time_", NpgsqlTypes.NpgsqlDbType.Timestamp, report.DateCreated);
                commandInsert.Parameters.AddWithValue("@longitude", NpgsqlTypes.NpgsqlDbType.Double, report.Longitude);
                commandInsert.Parameters.AddWithValue("@latitude", NpgsqlTypes.NpgsqlDbType.Double, report.Lattitude);
                commandInsert.Parameters.AddWithValue("@rating", NpgsqlTypes.NpgsqlDbType.Integer, report.Rating);
                commandInsert.Parameters.AddWithValue("@direction", NpgsqlTypes.NpgsqlDbType.Integer, Convert.ToInt32(report.Direction));
                commandInsert.Parameters.AddWithValue("@ban", NpgsqlTypes.NpgsqlDbType.Integer, Convert.ToInt32(report.Ban));
                commandInsert.ExecuteNonQuery();

                var dr = commandSelect.ExecuteReader(); //data reader
                if (dr.Read())
                {
                    NewReport = new Report
                    {
                        Id = new Guid(dr[0].ToString()),
                        Cause = (Cause)Convert.ToInt32(dr[1]),
                        DateCreated = Convert.ToDateTime(dr[2]),
                        Longitude = Convert.ToDouble(dr[3]),
                        Lattitude = Convert.ToDouble(dr[4]),
                        Rating = Convert.ToInt32(dr[5]),
                        Direction = (Direction)Convert.ToInt32(dr[6]),
                        Ban = (Ban)Convert.ToInt32(dr[7])
                    };
                }
                if (NewReport.Id == report.Id&&
                    NewReport.Cause == report.Cause &&
                    NewReport.DateCreated == report.DateCreated &&
                    NewReport.Longitude == report.Longitude &&
                    NewReport.Lattitude == report.Lattitude &&
                    NewReport.Rating == report.Rating &&
                    NewReport.Direction == report.Direction &&
                    NewReport.Ban == report.Ban )
                {
                    IsCreated = true;
                }
            }
            return IsCreated;
        }

        public List<IReportPOCO> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public IReportPOCO GetReport(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveReport(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
