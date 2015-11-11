using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TypeScript.Demo
{
    public static class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var _builder = new ContainerBuilder();

            //Call into our data project and let it register it's common services into the same builder
            TypeScript.Demo.Data.AutofacConfig.RegisterCommonServices(_builder);


            //This code is fairly stock code demonstrating how to tightly integrate Autofac with MVC and WebAPI
            _builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            _builder.RegisterModelBinders(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            _builder.RegisterModelBinderProvider();
            _builder.RegisterModule(new AutofacWebTypesModule());
            _builder.RegisterSource(new ViewRegistrationSource());
            _builder.RegisterFilterProvider();
            _builder.RegisterWebApiModelBinders(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            _builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            var _container = _builder.Build();

            // Tell ASP.NET MVC to use Autofac to resolve components
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

            // Create the depenedency resolver for web API
            var resolver = new AutofacWebApiDependencyResolver(_container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return _container;
        }
    }
}