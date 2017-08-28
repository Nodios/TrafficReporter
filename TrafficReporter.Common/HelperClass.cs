using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common
{
    public static class HelperClass
    {
        //This solution is inspired by this one: 
        //https://stackoverflow.com/questions/1772025/sql-data-reader-handling-null-column-values
        public static object GetDataSafely(this DbDataReader reader, string columnName)
        {
            return !reader[columnName].Equals(null) ? reader[columnName] : new object();
        }
    }
}
