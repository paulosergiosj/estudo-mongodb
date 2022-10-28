using MongoDB.Driver;
using VideoStore.Domain.Clients.Entities;

namespace VideoStore.Infra.Repositories
{
    public class ClientRepository : Repository<Client>
    {
        public ClientRepository(IMongoClient client)
           : base(client) { }
    }
}
