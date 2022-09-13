namespace DiggerScoreAdministration
{
    public sealed class OrderActionHistoryViewPage:IDisposable
    {
        public OrderActionHistoryViewPage()
        {
            Console.Clear();
            Console.Title="Order action history page";

            using (OrderActionHistoryRepository _ = new())
            {
                _.Read();
            }

            Console.WriteLine("Press << Escape >> to leave this page");
            while (Console.ReadKey().Key!=ConsoleKey.Escape) { }
        }

        public void Dispose() { }
    }
}