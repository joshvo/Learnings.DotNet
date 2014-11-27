using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Learnings.DotNet.Web.Startup))]
namespace Learnings.DotNet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
