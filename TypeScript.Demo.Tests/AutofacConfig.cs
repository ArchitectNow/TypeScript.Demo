using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScript.Demo.Tests
{
    public static class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var _builder = new ContainerBuilder();

            TypeScript.Demo.Data.AutofacConfig.RegisterCommonServices(_builder);

            var _container = _builder.Build();

            return _container;
        }
    }
}
