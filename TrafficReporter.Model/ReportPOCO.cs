using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using TrafficReporterService.Common;

namespace TrafficReporterModels
{
    public class ReportPOCO: IReportService
    {
        public Guid Id { get; set; }
        CauseEnum Cause { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid PictureId { get; set; }
        public int RatingPlus { get; set; }
        public int RatingMinus{ get; set; }
        DirectionEnum Direction { get; set; }
        BanEnum Ban { get; set; }
        public Guid UserId { get; set; }

        public bool AddReport()
        {
            throw new NotImplementedException();
        }
    }
}
