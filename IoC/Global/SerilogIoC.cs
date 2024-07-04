using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.Seq;

namespace IoC
{
    public class SerilogIoC
    {
        [Obsolete]
        public static void ConfigureSeqService(WebApplicationBuilder builder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            builder.Host.UseSerilog(Log.Logger);
        }
    }
}
