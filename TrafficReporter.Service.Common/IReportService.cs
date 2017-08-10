using TrafficReporter.Model;

namespace TrafficReporter.Service.Common
{
    public interface IReportService
    {
        bool AddReport(ReportPOCO report);
    }
}
