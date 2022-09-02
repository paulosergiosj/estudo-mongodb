using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoStore.Application.Categories.Interfaces;
using VideoStore.Application.Categories.Services;

namespace VideoStore.Application
{
    public static class AppExtensions
    {
        public static IServiceCollection AddAppDependencyInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICategoryService, CategoryService>();

            return serviceCollection;
        }
    }
}
