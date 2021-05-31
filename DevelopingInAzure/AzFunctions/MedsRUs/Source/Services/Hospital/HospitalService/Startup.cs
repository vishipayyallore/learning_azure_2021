using HospitalService.Config;
using HospitalService.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


[assembly: FunctionsStartup(typeof(HospitalService.Startup))]
namespace HospitalService
{

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            //builder.Services.AddSingleton<IMyService>((s) => {
            //    return new MyService();
            //});

            builder.Services.AddSingleton<IConnectionStrings, ConnectionStrings>();
        }
    }

}
