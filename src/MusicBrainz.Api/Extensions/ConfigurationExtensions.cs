namespace MusicBrainz.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void BuildConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Host.ConfigureAppConfiguration((_, config) => { config.AddEnvironmentVariables("MB_"); });
        }
    }
}
