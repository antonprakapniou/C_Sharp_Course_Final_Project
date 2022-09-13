using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Repositories;

namespace DiggerScoreClient.Pages
{
    public sealed class WelcomePage:BasePage,IDisposable
    {
        public WelcomePage()
        {
            PageName="Welcome page";

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
                    Console.WriteLine("Press any key to close this");
                    break;
                }
            }

            using (UserActionHistoryRepository _ = new())
            {
                _.Create(new("NonameUser", "visit site"));
            }
        }

        public void Dispose() { }
    }
}