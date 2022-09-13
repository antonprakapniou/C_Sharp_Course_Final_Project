namespace DiggerScoreAdministration
{
    public sealed class OrderActionHistory:BaseActionHistory
    {
        public OrderActionHistory(string?author,string?act)
        {
            Author = author;
            Act = act;
            Creation=DateTime.UtcNow;
        }

        public override string ToString() =>
            $"Author: {Author} {Act} in {Creation}";
    }
}