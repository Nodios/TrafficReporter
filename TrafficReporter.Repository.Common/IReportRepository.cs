using System;
using System.Collections.Generic;

using TrafficReporter.Model.Common;

namespace TrafficReporter.Repository.Common
{
    public interface IReportRepository
    {
        int AddReport(IReport report);


        IReport GetReport(Guid Id);

        bool RemoveReport(Guid Id);

        

    }
}
