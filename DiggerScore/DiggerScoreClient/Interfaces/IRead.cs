namespace DiggerScoreClient.Interfaces
{
    public interface IRead<T>
    {
        public T GetOne();

        public void Read();
    }
}