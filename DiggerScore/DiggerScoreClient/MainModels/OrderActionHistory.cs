using DiggerScoreClient.BaseModels;

namespace DiggerScoreClient.MainModels
{
    public sealed class OrderActionHistory : BaseActionHistory
    {
        public OrderActionHistory(string? author, string? act)
        {
            Author = author;
            Act = act;
            Creation = DateTime.UtcNow;
        }
    }
}