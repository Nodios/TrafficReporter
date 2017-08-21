using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Common.Enums;

namespace TrafficReporter.Common
{
    public class CauseFilter : ICauseFilter
    {
        #region Properties

        public Cause Cause { get; set; }
        public string SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }


        #endregion Properties

        #region Variables

        public int DefaultPageSize = 10;

        #endregion Variables

        //#region Constructor

        //public CauseFilter(CauseEnum Cause)
        //{

        //    this.Cause = Cause;

        //}

        //#endregion Constructor

        #region Methods

        public CauseFilter(int cause, int pageNumber, int pageSize)
        {
            try
            {
                Cause = (Cause) cause;
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