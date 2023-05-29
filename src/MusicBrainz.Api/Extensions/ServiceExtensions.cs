using Microsoft.EntityFrameworkCore;
using MusicBrainz.Core.Handlers;
using MusicBrainz.Core.Persistence;
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
            builder.Services.AddTransient<IAlbumSearchHandler, AlbumSearchHandler>();

            builder.Services.AddScoped<IArtistsRepository, ArtistRepository>();
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();

            var dbConnectionString = builder.Configuration.GetConnectionString("MusicBrainzConnectionString");

            builder.Services.AddDbContextPool<MusicBrainzDbContext>(op => op.UseSqlServer(connectionString: dbConnectionString));

            return builder;
        }
    }
}
