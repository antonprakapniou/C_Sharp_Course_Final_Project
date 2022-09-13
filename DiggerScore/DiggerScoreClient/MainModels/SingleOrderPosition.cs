namespace DiggerScoreClient.MainModels
{
    public sealed class SingleOrderPosition
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public SingleOrderPosition(string? fullName, double price, int count)
        {
            FullName=fullName;
            Price=price;
            Count=count;
        }

        public override string ToString() =>
            $"Id: {Id}\n" +
            $"Full name: {FullName}\n" +
            $"Price: {Price}\n" +
            $"Count: {Count}";
    }
}