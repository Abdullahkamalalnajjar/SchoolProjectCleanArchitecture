namespace SchoolProject.Api.Configurations.Cors;

public static class CorsExtension
{
    private const string PolicyName = "NedaaFedaa.Api";

    /// <summary>
    /// Add cors configurations
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <exception cref="Exception"></exception>
    public static IServiceCollection AddCorsSetup(this IServiceCollection services, IConfiguration configuration)
    {
        var corsConfiguration = new CorsConfigurations();
        configuration.Bind("Cors", corsConfiguration);

        if (corsConfiguration is null)
            throw new Exception("Couldn't load cors settings configuration");

        services.AddCors(options =>
        {
            options.AddPolicy(PolicyName, builder =>
            {
                builder.WithOrigins(corsConfiguration.Origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        return services;
    }

    /// <summary>
    /// setup cors origins
    /// </summary>
    /// <param name="app"></param>
    public static void UseCorsSetup(this IApplicationBuilder app)
    {
        app.UseCors(PolicyName);
    }
}