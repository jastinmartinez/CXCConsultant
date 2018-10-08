using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CXCConsultant.Startup))]
namespace CXCConsultant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
