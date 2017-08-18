using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common
{
    public class AreaFilter : IAreaFilter
    {
        #region Properties

        public double LowerLeftX { get; set; } = 44.5;
        public double LowerLeftY { get; set; } = 16.5;
        public double UpperRightX { get; set; } = 47.5;
        public double UpperRightY { get; set; } = 19.5;

        public string SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        #endregion

        #region Variables

        public int DefaultPageSize = 10;

        #endregion Variables

        //#region Constructor

        //// Trebamo od nekud povući lokaciju korisnika 
        //// Filtriranje je na strani baze podataka, onda samo proslijedimo LL i UR njima
        //public AreaFilter(double llX, double llY, double urX, double urY)
        //{
        //    LowerLeftX = llX;
        //    LowerLeftY = llY;
        //    UpperRightX = urX;
        //    UpperRightY = urY;

        //}

        //#endregion Constructor

        #region Methods

        public AreaFilter(double llX, double llY, double urX, double urY, int pageNumber, int pageSize)
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

        #endregion Methods

    }
}