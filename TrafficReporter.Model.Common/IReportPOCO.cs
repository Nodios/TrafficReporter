using System;
using System.Collections.Generic;
using TrafficReporter.Common;

namespace TrafficReporter.Model.Common
{
    public interface IReportPOCO
    {
        Guid Id { get; set; }
        CauseEnum Cause { get; set; }
        DateTime DateCreated { get; set; }
        int RatingPlus { get; set; }
        int RatingMinus { get; set; }
        DirectionEnum Direction { get; set; }
        Guid UserId { get; set; }
        float Latitude { get; set; }
        float Longitude { get; set; }
        VehicleTypeEnum VehicleType { get; set; }

    }
}
