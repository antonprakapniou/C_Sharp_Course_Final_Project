namespace DiggerScoreAdministration
{
    public interface IDbRepository<T>
    {
        public void Create(T _);
        public T GetById(int id);
        public void Read();
        public void Update(int id);
        public void Delete(int id);
    }
}