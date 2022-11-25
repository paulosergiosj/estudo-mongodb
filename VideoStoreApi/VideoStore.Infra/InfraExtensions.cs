using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using VideoStore.Domain.Base;
using VideoStore.Domain.Categories.Entities;
using VideoStore.Domain.Categories.Repositories;
using VideoStore.Domain.Models;
using VideoStore.Domain.Movies.Entities;
using VideoStore.Domain.Movies.Repositories;
using VideoStore.Infra.CollectionDefinitions;
using VideoStore.Infra.Constants;
using VideoStore.Infra.Repositories;

namespace VideoStore.Infra
{
    public static class InfraExtensions
    {
        public static IServiceCollection AddInfraDependencyInjection(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var clientSettings = MongoClientSettings.FromConnectionString(configuration.GetConnectionString(ConnectionStringsConstants.MONGODB));
                clientSettings.LinqProvider = MongoDB.Driver.Linq.LinqProvider.V3;
                return new MongoClient(clientSettings);
            });

            //serviceCollection.AddScoped<ICollectionDefinitions<Entity<ObjectId>>, CollectionDefinitions<Entity<ObjectId>>>();
            serviceCollection.AddScoped<ICollectionDefinitions<Category>, CategoryDefinitions>();
            serviceCollection.AddScoped<ICollectionDefinitions<Movie>, MovieDefinitions>();

            //serviceCollection.AddScoped<IRepository<Entity<ObjectId>>, Repository<Entity<ObjectId>>>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<IMovieRepository, MovieRepository>();
            serviceCollection.AddScoped<IServiceBuilderBase<Entity<ObjectId>>, ServiceBuilderBase<Entity<ObjectId>>>();

            return serviceCollection;
        }
    }
}
