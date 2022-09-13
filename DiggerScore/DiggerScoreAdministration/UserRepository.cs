namespace DiggerScoreAdministration
{
    internal class UserRepository : IDbRepository<User>, IDisposable
    {
        public void Create(User _)
        {
            using DiggerScoreDbContext db = new();
            db.Users.Add(_);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
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

        void IDisposable.Dispose() { }
    }
}