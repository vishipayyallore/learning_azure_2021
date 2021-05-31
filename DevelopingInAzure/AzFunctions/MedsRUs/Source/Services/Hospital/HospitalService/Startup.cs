using HospitalService.Config;
using HospitalService.Interfaces;
using HospitalService.Repositories;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


[assembly: FunctionsStartup(typeof(HospitalService.Startup))]
namespace HospitalService
{

    public class Startup : FunctionsStartup
    {

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IConnectionStrings, ConnectionStrings>();

            builder.Services.AddTransient<IMedicalSupplyOrderRepository, MedicalSupplyOrderRepository>();
        }

    }

}
