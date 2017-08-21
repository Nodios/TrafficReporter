using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficReporter.Model.Common;


namespace TrafficReporter.Model
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IReport>().To<Report>();
        }
    }
}
