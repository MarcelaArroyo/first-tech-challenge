using Prometheus.DotNetRuntime;

namespace FIAPCloudGames
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using (DotNetRuntimeStatsBuilder.Default().StartCollecting())
            {
                CreateHostBuilder(args).Build().Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    services.AddApiVersioning(options =>
                    {
                        options.ReportApiVersions = true;
                    });

                    services.AddVersionedApiExplorer(options =>
                    {
                        options.GroupNameFormat = "'v'VVV";
                        options.SubstituteApiVersionInUrl = true;
                    });
                });
    }
}
