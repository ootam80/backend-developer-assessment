using MusicBrainz.Api.Extensions;
using MusicBrainz.Core.Handlers;
using MusicBrainz.Core.Models;
using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);


builder.BuildConfiguration();

builder
    .AddSerilogLogger()
    .AddServices();

var app = builder.Build();

app.MapGet("/artist/search/{searchCriteria}/{pageNumber}/{pageSize}", FetchArtists);


async Task<IResult> FetchArtists(string searchCriteria, int pageNumber, int pageSize, IArtistSearchHandler artistSearchHandler, CancellationToken cancellationToken)
{
    var request = new ArtistSearchRequest { SearchCriteria = searchCriteria, PageNumber = pageNumber, PageSize = pageSize };

    var result = await artistSearchHandler.HandleAsync(request, cancellationToken);

    return result.Match(
        ok => Results.Json(data: ok, statusCode: 200),
        notFound => Results.Json(notFound, statusCode: 404),
        error => Results.Json(error, statusCode: 500));
}

var logger = app.Services.GetRequiredService<ILogger>();

try
{
    app.Run();
    logger.Information("Application is running...");
}
catch (Exception e)
{
    logger.Error(e, "An error occurred while starting the application...");
}
finally
{
    Log.CloseAndFlush();
    await Task.Delay(1000);
}

// http://localhost:5035/artist/search/test/1/200