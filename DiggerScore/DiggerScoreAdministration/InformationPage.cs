using DiggerScoreAdministration.Services;

namespace DiggerScoreAdministration
{
    public sealed class InformationPage:IDisposable
    {
        public InformationPage()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Task task = AdministrationService.GetNewOrderActionHistoryAsync();
            task.Wait();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nPress << Escape >> to leave this page");
            while (Console.ReadKey().Key!=ConsoleKey.Escape) { }
        }

        public void Dispose() { }
    }
}