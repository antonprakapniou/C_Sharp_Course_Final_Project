using DiggerScoreClient.Contexts;
using DiggerScoreClient.Interfaces;
using DiggerScoreClient.MainModels;

namespace DiggerScoreClient.Repositories
{
    public sealed class OrderActionHistoryRepository : IDbRepository<OrderActionHistory>, IDisposable
    {
        public void Create(OrderActionHistory _)
        {
            using DiggerScoreDbContext db = new();
            db.OrderActionHistories.Add(_);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose() { }

        public OrderActionHistory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}