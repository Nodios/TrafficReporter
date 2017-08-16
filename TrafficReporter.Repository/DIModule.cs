using Ninject;
using System.Collections.Generic;
using AutoMapper;
using Ninject.Modules;
using TrafficReporter.Repository.Common;


namespace TrafficReporter.Repository
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(ctx =>
            {
                var profiles = ctx.Kernel.Get<List<Profile>>();
                var config = new MapperConfiguration(
    c =>
    {

        foreach (var profile in profiles)
        {
            c.AddProfile(profile);
        }
    });
                // Solution starts here
                var mapper = config.CreateMapper();
                return mapper;
            }).InSingletonScope();




            Bind<IReportRepository>().To<ReportRepository>();
            



        }
        


    }


    }
    

