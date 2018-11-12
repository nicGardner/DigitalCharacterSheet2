using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DigitalCharacterSheet2.Startup))]
namespace DigitalCharacterSheet2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
