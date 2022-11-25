using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoStore.Application.Categories.Interfaces;
using VideoStore.Application.Categories.Mappers;
using VideoStore.Application.Categories.Services;
using VideoStore.Application.Categories.Validators;
using VideoStore.Application.Movies.Interfaces;
using VideoStore.Application.Movies.Mappers;
using VideoStore.Application.Movies.Services;
using VideoStore.Application.Movies.Validators;
using VideoStore.Domain.Base;
using VideoStore.Domain.Categories.Contracts;
using VideoStore.Domain.Movies.Contracts;

namespace VideoStore.Application
{
    public static class AppExtensions
    {
        public static IServiceCollection AddAppDependencyInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IMovieService, MovieService>();
            serviceCollection.AddTransient<IMovieMapper, MovieMapper>();
            serviceCollection.AddTransient<ICategoryMapper, CategoryMapper>();
            serviceCollection.AddTransient<IValidator<MovieCommand>, MovieCommandValidator>();
            serviceCollection.AddTransient<IValidator<CategoryCommand>, CategoryCommandValidator>();
            serviceCollection.AddTransient<ICategoryServiceBuilder, CategoryServiceBuilder>();
            serviceCollection.AddTransient<IMovieServiceBuilder, MovieServiceBuilder>();

            return serviceCollection;
        }
    }
}
