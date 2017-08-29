using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrafficReporter.Common.Filter
{
    public class Filters :IFilter
    {
        // fixed parameter values define the area (using point coordinates) in which application users can report incidents
        public double LowerLeftX { get; set; } 
        public double LowerLeftY { get; set; } 
        public double UpperRightX { get; set; } 
        public double UpperRightY { get; set; }
        public int Cause { get; set; }
        public string SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }




        #region Variables

        private const int DefaultPageNumber = 1;
        private const int DefaultPageSize = 10;

        #endregion Variables

        #region Constructor

        public Filters(string causeString)
        {

            

        }

        #endregion Constructor

        public Filters(double llX, double llY, double urX, double urY, int cause = 0, int pageNumber = DefaultPageNumber, int pageSize = DefaultPageSize)
        {
            try
            {
                LowerLeftX = llX;
                LowerLeftY = llY;
                UpperRightX = urX;
                UpperRightY = urY;
                Cause = cause;
                PageNumber = pageNumber;
                PageSize = pageSize;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }


    }
}
