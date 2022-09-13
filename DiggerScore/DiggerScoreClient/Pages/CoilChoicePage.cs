using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Repositories;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Pages
{
    public sealed class CoilChoicePage:BaseChoicePage,IDisposable
    {
        public CoilChoicePage()
        {
            PageName="Coil page name";

            Coil? currentProduct = default;

            using (CoilRepository _ = new())
            {
                _.ReadAsync().Wait();
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