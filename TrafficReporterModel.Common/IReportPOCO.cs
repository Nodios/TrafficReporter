using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;


namespace TrafficReporterModel.Common
{
    public interface IReportPOCO
    {
        Guid Id { get; set; }
        CauseEnum Cause { get; set; }
        DateTime DateCreated { get; set; }
        Guid PictureId { get; set; }
        int Rating { get; set; }
        DirectionEnum Direction { get; set; }
        BanEnum Ban { get; set; }
        Guid UserId { get; set; }


        List<IPicturePOCO> Picture { get; set; }
        List<IUserPOCO> User { get; set; }
    }
}
