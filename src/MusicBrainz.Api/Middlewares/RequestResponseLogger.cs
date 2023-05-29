using System.Diagnostics;
using Serilog;
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

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = new Stopwatch();

            var correlationId = context.Request.Headers.TryGetValue(CorrelationIdHeaderKey, out var value) ? value.FirstOrDefault() : context.TraceIdentifier;

            sw.Start();

            using (LogContext.PushProperty("CorrelationId", correlationId))
            { 
                await _next.Invoke(context);

                sw.Stop();

                _logger.Information(MessageTemplate, context.Request.Path, sw.ElapsedMilliseconds);
            }
        }
    }
}
