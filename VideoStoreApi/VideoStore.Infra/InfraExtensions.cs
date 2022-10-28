using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using VideoStore.Domain.Base;
using VideoStore.Domain.Categories.Repositories;
using VideoStore.Domain.Models;
using VideoStore.Domain.Movies.Repositories;
using VideoStore.Infra.Constants;
using VideoStore.Infra.Repositories;

namespace VideoStore.Infra
{
    public static class InfraExtensions
    {
        public static IServiceCollection AddInfraDependencyInjection(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            serviceCollection.AddSingleton<IMongoClient, MongoClient>(sp => new
            MongoClient(configuration.GetConnectionString(ConnectionStringsConstants.MONGODB)));

            serviceCollection.AddTransient<IRepository<Entity<ObjectId>>, Repository<Entity<ObjectId>>>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddTransient<IMovieRepository, MovieRepository>();
            serviceCollection.AddTransient<IServiceBuilderBase<Entity<ObjectId>>, ServiceBuilderBase<Entity<ObjectId>>>();

            return serviceCollection;
        }
    }
}
