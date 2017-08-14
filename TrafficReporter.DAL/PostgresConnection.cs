using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Common;

namespace TrafficReporter.DAL
{
    public class PostgresConnection : IPostgresConnection
    {
        private string connString = "Host=localhost; Port=5432; Username=postgres; Password=postgres; Database=TrafficReporter";

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connString);
        }
    }
}
