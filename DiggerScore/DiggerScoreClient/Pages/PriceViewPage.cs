using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Repositories;
using Validation;

namespace DiggerScoreClient.Pages
{
    public sealed class PriceViewPage:BasePage, IDisposable
    {
        public override string? PageName { get; set; } = "Price view page";

        public PriceViewPage()
        {
            using (MetalDetectorRepository _=new())
            {
                Task task = _.ReadAsync();
                task.Wait();
            }

            using (CoilRepository _ = new())
            {
                Task task = _.ReadAsync();
                task.Wait();
            }

            using (OtherProductRepository _ = new())
            {
                Task task = _.ReadAsync();
                task.Wait();
            }

            Log!.Information("Noname user view the price".WithCurrentThreadId());
            Console.WriteLine("\nPress << Escape >> to leave this page");
            while (Console.ReadKey().Key!=ConsoleKey.Escape) { }
        }

        public void Dispose() { }
    }
}