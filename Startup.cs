using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OsAccountingApp1.Startup))]
namespace OsAccountingApp1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
