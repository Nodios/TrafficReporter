using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using TrafficReporter.Common.Filter;

namespace TrafficReporter.Common
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFilterFactory>().To<FilterFactory>();
        }
    }
}
