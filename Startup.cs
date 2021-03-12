using ApiRuletaOnline.Repositories;
using ApiRuletaOnline.Services;
using EasyCaching.Core.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiRuletaOnline
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
            services.AddScoped<IRouletteRepository, RouletteRepository>();
            services.AddScoped<IRouletteService, RouletteService>();
            services.AddEasyCaching(options =>{
                options.UseRedis(redisConfig =>{
                    redisConfig.DBConfig.Endpoints.Add(new ServerEndPoint("redisdb", 6379));
                    redisConfig.DBConfig.AllowAdmin = true;
                },
                    "roulette");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
