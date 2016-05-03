using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmailValidatorService.Startup))]
namespace EmailValidatorService
{
    public partial class Startup
    {
        public Startup()
        {
            //MLManager.InitializeHelper.InitialDataFromMongoDB();
        }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
