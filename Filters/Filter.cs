using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficReporter.Common.Filters
{
    public class Filter : IFilter
    {
        #region Properties

        public Location LowerLeft { get; set; }
        public Location UpperRight { get; set; }
        public CauseEnum Cause { get; set; }

        // public BanEnum BanType { get; set; }   Odustali od BanType-a jer ga nema tko unijeti

        // public String Destination { get; set; }  Dodatni "feature" - korisnik unese odredište pa ga zanimaju eventi samo na tom putu
        #endregion

        #region Variables

        //private int DefaultSearchRadius = 30;

        #endregion Variables

        #region Constructor

        // Trebamo od nekud povući lokaciju korisnika 
        // Filtriranje je na strani baze podataka, onda samo proslijedimo LL i UR njima
        public Filter(Location LL, Location UR, CauseEnum Cause)
        {
            // SearchRadius = (SearchArea > 0) ? SearchArea : DefaultSearchRadius;
            LowerLeft = LL;
            UpperRight = UR;
            this.Cause = Cause;

        }

        #endregion Constructor

        #region Methods

        // trebamo proslijediti kriterije filtriranja

        public string SendFilterCriteria()
        {

        }
        public string RetrieveFiltered()
        {

        } 

        #endregion Methods

    }
}
