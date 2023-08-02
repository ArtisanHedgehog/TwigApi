using Pchp.Core;
using Twig.Loader;

namespace TwigApi;

public static class DependencyInjection
{
    public static IServiceCollection AddTwig(this IServiceCollection services)
    {
        services.AddScoped<LoaderInterface, FilesystemLoader>(c => new FilesystemLoader("Templates"));
        services.AddScoped(c => new Twig.Environment(c.GetService<LoaderInterface>(), PhpValue.Null));

        return services;
    }
}
