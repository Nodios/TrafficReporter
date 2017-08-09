using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporterModel.Common
{
    public interface IPicturePOCO
    {
        Guid Id { get; set; }
        byte[] PicArray { get; set; }
    }
}
