namespace DiggerScoreAdministration
{
    public sealed class CoilRepository : IDbRepository<Coil>, IDisposable
    {
        public void Create(Coil _)
        {
            using DiggerScoreDbContext db = new();
            db.Coils.Add(_);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose() { }

        public Coil GetById(int id)
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