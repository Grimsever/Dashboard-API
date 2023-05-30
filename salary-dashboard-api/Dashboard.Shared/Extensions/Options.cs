using Microsoft.Extensions.Configuration;

namespace Dashboard.Shared.Extensions
{
    public static class Options
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
            where TOptions : new()
        {
            var options = new TOptions();
            configuration.GetSection(sectionName).Bind(options);

            return options;
        }
    }
}
