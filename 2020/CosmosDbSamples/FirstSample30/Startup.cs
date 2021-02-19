using FirstSample30.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Cosmos.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FirstSample30
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<CollegeDbContext>(o => o.UseCosmos(
            //    "https://localhost:8081/",
            //    "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
            //    "webapidemodb",
            //    optionBuilder =>
            //    {
            //        optionBuilder.ExecutionStrategy(d => new CosmosExecutionStrategy(d, 10));
            //    }
            //    ));

            //services.AddDbContext<CollegeDbContext>(options =>
            //    {
            //            options.UseCosmos("https://localhost:8081/", 
            //                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
            //                "webapidemodb");
            //    }, ServiceLifetime.Transient);

            services.AddDbContext<NoSqlDbContext>(options =>
              options.UseCosmos(
                  //I use user secrets to provide the actual Azure Cosmos database, but fall back to local emulator if no secrets set
                  Configuration["CosmosUrl"] ?? Configuration["endpoint"],
                  Configuration["CosmosKey"] ?? Configuration["authKey"],
                  Configuration["database"]));

            services.AddDbContext<CollegeDbContext>(options =>
                options.UseCosmos(
                    "https://localhost:8081/",
                    "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                    "webapidemodb"));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
