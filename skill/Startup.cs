using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(skill.Startup))]
namespace skill
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
