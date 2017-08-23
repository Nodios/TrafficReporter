using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Common.Enums;

namespace TrafficReporter.Common.Filter
{
    public class Filters :IFilter
    {
        // fixed parameter values define the area (using point coordinates) in which application users can report incidents
        public double LowerLeftX { get; set; } = 44.5;
        public double LowerLeftY { get; set; } = 16.5;
        public double UpperRightX { get; set; } = 47.5;
        public double UpperRightY { get; set; } = 19.5;
        public Cause Cause { get; set; }
        public string SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }




        #region Variables

        public int DefaultPageSize = 10;

        #endregion Variables

        //#region Constructor

        //public CauseFilter(CauseEnum Cause)
        //{

        //    this.Cause = Cause;

        //}

        //#endregion Constructor



        public Filters(int cause, int pageNumber, int pageSize)
        {
            try
            {
                Cause = (Cause)cause;
                SetPageNumberAndSize(pageNumber, pageSize);
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        public Filters(double llX, double llY, double urX, double urY, int pageNumber, int pageSize)
        {
            try
            {
                LowerLeftX = llX;
                LowerLeftY = llY;
                UpperRightX = urX;
                UpperRightY = urY;

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
