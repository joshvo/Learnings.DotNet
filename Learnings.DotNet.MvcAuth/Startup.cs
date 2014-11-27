using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Learnings.DotNet.MvcAuth.Startup))]
namespace Learnings.DotNet.MvcAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
