using System;
using System.Collections.Generic;

using TrafficReporter.Model.Common;

namespace TrafficReporter.Repository.Common
{
    public interface IReportRepository
    {
        bool AddReport(IReportPOCO report);

        

        IReportPOCO GetReport(Guid Id);

        bool RemoveReport(Guid Id);

        

    }
}
