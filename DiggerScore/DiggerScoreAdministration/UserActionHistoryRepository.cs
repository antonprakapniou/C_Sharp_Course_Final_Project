using Validation;

namespace DiggerScoreAdministration
{
    internal sealed class UserActionHistoryRepository : IDbRepository<UserActionHistory>, IDisposable
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

        public void Read()
        {
            using (DiggerScoreDbContext db = new())
            {
                db.UserActionHistories.ToList().ToConsoleTable(
                    new Dictionary<string, string>
                    {
                        {"Id","Id" },
                        {"Author","Author" },
                        {"Act","Act" },
                        {"Creation","Creation" }
                    });
            }
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}