using System.Diagnostics;
using Serilog.Context;

namespace MusicBrainz.Api.Middlewares
{
    internal sealed class RequestResponseLogger
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;

        private const string MessageTemplate = "HTTP request on {Path} message took {Duration} ms to complete";

        private const string CorrelationIdHeaderKey = "Correlation-Id";

        public RequestResponseLogger(RequestDelegate next, Serilog.ILogger logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger.ForContext<RequestResponseLogger>() ?? throw new ArgumentNullException(nameof(logger));
        }

        // Given that the API only exposes HTTP GET endpoints, there is no need to log request.
        public async Task InvokeAsync(HttpContext context)
        {
            var sw = new Stopwatch();

            var correlationId = context.Request.Headers.TryGetValue(CorrelationIdHeaderKey, out var value) ? value.FirstOrDefault() : context.TraceIdentifier;

            sw.Start();

            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                try
                {
                    var originalResponseBody = context.Response.Body;
                    using (var responseBody = new MemoryStream())
                    {
                        context.Response.Body = responseBody;
                        await _next.Invoke(context);

                        sw.Stop();

                        await LogResponseAsync(context, responseBody, originalResponseBody, sw.ElapsedMilliseconds);
                    }
                }
                catch (Exception e)
                {
                    sw.Stop();

                    _logger
                        .Error(e, MessageTemplate, context.Request.Path, sw.ElapsedMilliseconds);
                }
            }
        }

        private async Task LogResponseAsync(HttpContext context, MemoryStream responseBody, Stream originalResponseBody, long elapsed)
        {
            responseBody.Position = 0;
            var content = await new StreamReader(responseBody).ReadToEndAsync();

            responseBody.Position = 0;
            await responseBody.CopyToAsync(originalResponseBody);
            context.Response.Body = originalResponseBody;

            _logger
                .ForContext("Response", content, true)
                .Information(MessageTemplate, context.Request.Path, elapsed);
        }
    }
}
