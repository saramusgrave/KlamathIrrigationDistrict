using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KlamthIrrigationDistrict.Startup))]
namespace KlamthIrrigationDistrict
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
