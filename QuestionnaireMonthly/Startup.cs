using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuestionnaireMonthly.Startup))]
namespace QuestionnaireMonthly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
