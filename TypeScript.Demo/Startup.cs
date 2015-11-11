using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TypeScript.Demo.Startup))]
namespace TypeScript.Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}
