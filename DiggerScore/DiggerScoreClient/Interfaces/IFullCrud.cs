namespace DiggerScoreClient.Interfaces
{
    public interface IFullCrud<T>:IRead<T>
    {
        public void Create(T _);

        public void Update(T _);
    }
}