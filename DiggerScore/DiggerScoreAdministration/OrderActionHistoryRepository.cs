using Validation;

namespace DiggerScoreAdministration
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
            using (DiggerScoreDbContext db=new())
            {
                db.OrderActionHistories.ToList().ToConsoleTable(
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