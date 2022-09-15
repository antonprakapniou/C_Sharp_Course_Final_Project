using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Repositories;

namespace DiggerScoreClient.Pages
{
    public sealed class MainPage:BasePage,IDisposable
    {
        public override string? PageName { get; set; } = "Main page";

        public MainPage()
        {
            Log!.Debug($"App started in [{Environment.CurrentManagedThreadId}] thread");
            Log!.Information($"Score opened in [{Environment.CurrentManagedThreadId}] thread");

            GetTitle();
            
            string? welcomeMessage =
                "\n\tHello Friend!!!\n" +
                "We welcome you to our store and\n" +
                "wish you to find here everything\n" +
                "you need to find a real treasure\n";

            string? inputMessage =
                "\nPress\n" +
                "<< 1 >> to see price\n" +
                "<< 2 >> to buy anything\n" +
                "<< other key >> to exit";

            string? exitMessage =
                "\nThanks for visiting our store!\n" +
                "No nails or plugs\n" +
                "and swag under the coil))\n";

            while (true)
            {
                Console.Clear();
                Console.WriteLine(welcomeMessage);
                Console.WriteLine(inputMessage);

                string?answer=Console.ReadLine();

                if (answer!.Equals("1"))
                {
                    PriceViewPage _ = new();
                }

                else if (answer!.Equals("2"))
                {
                    ShoppingPage _ = new();
                } 
                
                else
                {
                    Console.WriteLine(exitMessage);
                    Console.WriteLine("Press << Escape >> to close this");
                    while (Console.ReadKey().Key!=ConsoleKey.Escape) { }
                    break;
                }
            }

            using (UserActionHistoryRepository _ = new())
            {
                _.Create(new("NonameUser", "visit site"));
            }

            Log.Information($"Score closed in [{Environment.CurrentManagedThreadId}] thread");
            Log.Debug($"App stopped in [{Environment.CurrentManagedThreadId}] thread");
        }

        public void Dispose() { }
    }
}