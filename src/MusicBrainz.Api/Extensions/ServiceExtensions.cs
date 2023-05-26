using MusicBrainz.Core.Handlers;
using Serilog;
using Serilog.Exceptions;

namespace MusicBrainz.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static WebApplicationBuilder AddSerilogLogger(this WebApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.WithMachineName()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .CreateLogger();

            builder.Services.AddSingleton(Log.Logger);
            builder.Host.UseSerilog();

            return builder;
        }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddTransient<IArtistSearchHandler, ArtistSearchHandler>();

            return builder;
        }
    }
}
