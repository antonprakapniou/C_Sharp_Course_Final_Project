using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Repositories;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Pages
{
    public sealed class CoilChoicePage:BaseChoicePage,IDisposable
    {
        public override string? PageName { get; set; } = "Coil choice page";

        public CoilChoicePage()
        {
            Coil? currentProduct = default;

            using (CoilRepository _ = new())
            {
                _.ReadAsync().Wait();
                Log!.Information("Coil price view".WithCurrentThreadId());
            }

            using (CoilRepository _ = new())
            {
                Task<Coil> task = _.GetOneAsync();
                task.Wait();
                currentProduct=task.Result;
            }

            int count = TypeConsoleInput.IntValue("Count is", "Invalid value. Try again");

            CurrentOrder=new(currentProduct.ProductType+" "+currentProduct.Producer+" "+currentProduct.Model, currentProduct.Price, count);
        }

        public void Dispose() { }
    }
}