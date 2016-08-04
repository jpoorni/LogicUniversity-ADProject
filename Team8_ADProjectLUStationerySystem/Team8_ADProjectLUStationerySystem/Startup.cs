using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Team8_ADProjectLUStationerySystem.Startup))]
namespace Team8_ADProjectLUStationerySystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
