using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporterModel.Common
{
    public interface IUserPOCO
    {
        Guid Id { get; set; }
        string ImePrezime { get; set; }
    }
}
