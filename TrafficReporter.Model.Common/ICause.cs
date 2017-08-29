using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Model.Common
{
    public interface ICause
    {
        /// <summary>
        /// Identifier(in db, like flag enum)
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// This data is used for passing icons.
        /// </summary>
        string DataUri { get; set; }

        /// <summary>
        /// Name for a cause.
        /// </summary>
        string Name { get; set; }

    }
}
