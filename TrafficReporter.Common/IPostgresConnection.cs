using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common
{
    public interface IPostgresConnection
    {
        NpgsqlConnection GetConnection();
    }
}
