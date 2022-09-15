using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Contexts;
using DiggerScoreClient.MainModels;
using Validation;

namespace DiggerScoreClient.Repositories
{
    public sealed class OrderActionHistoryRepository:BaseRepository
    {
        public void Create(OrderActionHistory _)
        {
            using DiggerScoreDbContext db = new();
            {
                Log!.Debug("Order action history database access".WithCurrentThreadId());
                db.OrderActionHistories.Add(_);
                db.SaveChanges();
            }
        }
    }
}