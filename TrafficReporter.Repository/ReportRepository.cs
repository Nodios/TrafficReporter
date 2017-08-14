using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrafficReporter.Model.Common;
using TrafficReporter.Repository.Common;

namespace TrafficReporter.Repository
{
    public class ReportRepository : IReportRepository
    {
        public bool AddReport(IReport report)
        {
            throw new NotImplementedException();
        }

        public List<IReport> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public IReport GetReport(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveReport(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
