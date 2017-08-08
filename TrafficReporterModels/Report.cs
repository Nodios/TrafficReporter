using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporterModel.Common;

namespace TrafficReporterModels
{
    public class Report
    {
        Guid Id { get; set; }
        Cause Cause { get; set; }
        DateTime DateCreated { get; set; }
        Boolean Active { get; set; }
        Guid PictureId { get; set; }
        int Rating { get; set; }
    }
}
