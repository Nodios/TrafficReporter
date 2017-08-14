using TrafficReporter.Model;
using TrafficReporter.Model.Common;

namespace TrafficReporter.Service.Common
{
    public interface IReportService
    {
        bool AddReport(IReport report);
    }
}
