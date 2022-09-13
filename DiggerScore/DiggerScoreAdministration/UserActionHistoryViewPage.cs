namespace DiggerScoreAdministration
{
    public sealed class UserActionHistoryViewPage:IDisposable
    {
        public UserActionHistoryViewPage()
        {
            Console.Clear();
            Console.Title="User action history page";

            using (UserActionHistoryRepository _=new())
            {
                _.Read();
            }
                
            Console.WriteLine("Press << Escape >> to leave this page");
            while (Console.ReadKey().Key!=ConsoleKey.Escape) { }
        }

        public void Dispose() { }
    }
}