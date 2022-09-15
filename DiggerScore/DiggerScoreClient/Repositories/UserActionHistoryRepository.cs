using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Contexts;
using DiggerScoreClient.MainModels;
using Validation;

namespace DiggerScoreClient.Repositories
{
    public sealed class UserActionHistoryRepository : BaseRepository
    {
        public void Create(UserActionHistory _)
        {
            using (DiggerScoreDbContext db = new())
            {
                Log!.Debug("User action history database access".WithCurrentThreadId());
                db.UserActionHistories.Add(_);
                db.SaveChanges();
            }
            
        }
    }
}