using DiggerScoreAdministration.Services;

namespace DiggerScoreAdministration
{
    public sealed class OpenClosePage : IDisposable
    {
        public OpenClosePage()
        {
            using (InformationPage _ = new()) { }

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            string? inputMessage =
                "\nPress\n" +
                "<< 1 >> to view user action history\n" +
                "<< 2 >> to view order action history\n" +
                "<< 3 >> to set discount\n" +
                "<< other key >> to exit";

            while (true)
            {
                Console.Clear();
                Console.Title="Digger Score Administration";
                Console.WriteLine(inputMessage);

                string? answer = Console.ReadLine();

                if (answer!.Equals("1"))
                {
                    using UserActionHistoryViewPage _ = new();
                }

                else if (answer!.Equals("2"))
                {
                    using OrderActionHistoryViewPage _ = new();
                }

                else if (answer!.Equals("3"))
                {
                    using SetDiscountPage _ = new();
                }

                else
                {
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
