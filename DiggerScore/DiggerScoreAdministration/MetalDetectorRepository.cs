namespace DiggerScoreAdministration
{
    public sealed class MetalDetectorRepository : IDbRepository<MetalDetector>, IDisposable
    {
        public void Create(MetalDetector _)
        {
            using DiggerScoreDbContext db = new();
            db.MetalDetectors.Add(_);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MetalDetector GetById(int id)
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
