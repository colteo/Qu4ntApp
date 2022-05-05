using Repositories.MongoDB;
using MongoDB.Driver;
using Domain.Entities.Prova;
using Domain.Entities.Strategy;

namespace Repositories.Context
{
    public class StrategyDbContext /*: IDisposable*/
    {
        private readonly IMongoDatabase _db;
        private readonly IClientSessionHandle _session;
        private bool _disposed;

        public StrategyDbContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
            //_session = client.StartSession();
            //_session.StartTransaction();
        }
        public IMongoCollection<Strategy> Strategies => _db.GetCollection<Strategy>("Strategies");

        internal IClientSessionHandle Session => _session;

        public async Task SaveChangesAsync()
        {
            await this.Session.CommitTransactionAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    this.Session.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
