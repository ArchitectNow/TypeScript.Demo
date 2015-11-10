using ArchitectNow.Framework.Utilities;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeScript.Demo.Data.Repositories;

namespace TypeScript.Demo.Data
{
    public static class AutofacConfig
    {
        public static void RegisterCommonServices(ContainerBuilder Builder)
        {
            var _environmentName = SettingsUtilities.GetSetting("EnvironmentName");

            Builder.RegisterType<MoqPersonRepository>().As<IPersonRepository>().PropertiesAutowired();
           
        }
    }
}
