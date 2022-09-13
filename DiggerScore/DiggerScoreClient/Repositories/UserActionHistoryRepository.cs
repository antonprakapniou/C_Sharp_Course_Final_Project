using DiggerScoreClient.Contexts;
using DiggerScoreClient.Interfaces;
using DiggerScoreClient.MainModels;

namespace DiggerScoreClient.Repositories
{
    public sealed class UserActionHistoryRepository : IDbRepository<UserActionHistory>, IDisposable
    {
        public void Create(UserActionHistory _)
        {
            using DiggerScoreDbContext db = new();
            db.UserActionHistories.Add(_);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose() { }

        public UserActionHistory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Read() { }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}