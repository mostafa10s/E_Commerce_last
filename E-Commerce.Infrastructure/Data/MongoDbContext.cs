
using Microsoft.Extensions.Options;


namespace E_Commerce.Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongSettings> mongSettings)
        {
            var client = new MongoClient(mongSettings.Value.ConcationUrl);
            _database = client.GetDatabase(mongSettings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>( string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
