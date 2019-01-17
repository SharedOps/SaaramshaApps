using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Saaramsha.Repositery.Interfaces;
using Saaramsha.Repositery.Providers;
using SaaramshaApps.Interfaces;
using SaaramshaApps.Services;

namespace SaaramshaApps.Autofac
{
    public class DataModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DapperService>().As<IDapperService>();
            builder.RegisterType<SaaramshaUserService>().As<ISaaramshaUserService>();
            builder.RegisterType<SaaramshaProjectService>().As<ISaaramshaProjectService>();
           
        }
    }
}