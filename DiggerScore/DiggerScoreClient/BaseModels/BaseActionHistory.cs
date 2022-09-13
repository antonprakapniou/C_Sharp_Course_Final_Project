namespace DiggerScoreClient.BaseModels
{
    public abstract class BaseActionHistory
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Act { get; set; }
        public DateTime? Creation { get; set; }
    }
}