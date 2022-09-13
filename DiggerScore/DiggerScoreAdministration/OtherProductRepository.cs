namespace DiggerScoreAdministration
{
    public sealed class OtherProductRepository : IDbRepository<OtherProduct>, IDisposable
    {
        public void Create(OtherProduct _)
        {
            using DiggerScoreDbContext db = new();
            db.OtherProducts.Add(_);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OtherProduct GetById(int id)
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