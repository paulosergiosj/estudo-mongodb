using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoStore.Application.Categories.Interfaces;
using VideoStore.Application.Categories.Services;
using VideoStore.Application.Movies.Interfaces;
using VideoStore.Application.Movies.Mappers;
using VideoStore.Application.Movies.Services;

namespace VideoStore.Application
{
    public static class AppExtensions
    {
        public static IServiceCollection AddAppDependencyInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IMovieService, MovieService>();
            serviceCollection.AddTransient<IMovieMapper, MovieMapper>();
            serviceCollection.AddTransient<ICategoryValidator, CategoryValidator>();

            return serviceCollection;
        }
    }
}
