using TrafficReporter.Model;

namespace TrafficReporter.Repository.Common
{
    public interface IReportRepository
    {
        bool AddReport(ReportPOCO report);
}
}
