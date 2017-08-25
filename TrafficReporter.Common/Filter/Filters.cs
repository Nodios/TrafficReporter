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
        public string Cause { get; set; }
        public List<int> CauseCollection { get; set; }
        public string SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }




        #region Variables

        public int DefaultPageSize = 10;

        #endregion Variables

        #region Constructor

        public Filters(string causeString)
        {

            

        }

        #endregion Constructor



        public Filters(string causeString, int pageNumber, int pageSize)
        {
            
        }

        public Filters(double llX, double llY, double urX, double urY, string causeString, int pageNumber, int pageSize)
        {
            try
            {
                LowerLeftX = llX;
                LowerLeftY = llY;
                UpperRightX = urX;
                UpperRightY = urY;
                Cause = causeString;

                

                SetPageNumberAndSize(pageNumber, pageSize);
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }


        private void SetPageNumberAndSize(int pageNumber = 1, int pageSize = 0)
        {
            PageNumber = (pageNumber > 0) ? pageNumber : 1;
            PageSize = (pageSize > 0 && pageSize <= DefaultPageSize) ? pageSize : DefaultPageSize;
        }

    }
}
