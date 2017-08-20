using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IC_Assignment.Startup))]
namespace IC_Assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
