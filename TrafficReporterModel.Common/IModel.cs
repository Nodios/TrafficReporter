using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporterModel.Common
{
    public class IModel
    {
        Guid Id { get; set; }
        Cause Cause { get; set; }
        DateTime DateCreated { get; set; }
        Boolean Active { get; set; }
        Guid PictureId { get; set; }
        int Rating { get; set; }

    }
}
