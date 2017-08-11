using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Repository.Common
{
    public interface IReportRepository
    {
        bool AddReport(Guid Id);

        List<IReportPOCO> GetAllReports();

        bool RemoveReport(Guid Id);
        
    }
}
