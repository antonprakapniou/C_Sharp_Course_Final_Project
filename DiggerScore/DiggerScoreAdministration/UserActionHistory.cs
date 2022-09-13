namespace DiggerScoreAdministration
{
    public sealed class UserActionHistory:BaseActionHistory
    {
        public UserActionHistory(string? author, string? act)
        {
            Author = author;
            Act = act;
            Creation=DateTime.UtcNow;
        }
    }
}