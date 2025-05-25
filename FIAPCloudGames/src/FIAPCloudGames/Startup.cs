using FIAPCloudGames.DependencyInjection.Swagger;
using FIAPCloudGames.Infrastructure.DependencyInjection.Extensions;

namespace FIAPCloudGames
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfiguration(Configuration);
            services.AddEntityFrameworkCoreConfiguration(Configuration);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error")
                   .UseHsts();
            }
            app.UseHttpsRedirection()
               .UseStaticFiles()
               .UseRouting()
               .UseAuthorization()
               .UseSwaggerSetup()
               .UseEndpoints(endpoints =>
               {
                    endpoints.MapControllers();
               });
        }
    }
}
