using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Contexts;
using DiggerScoreClient.Repositories;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Pages
{
    public class OtherProductChoicePage:BaseChoicePage,IDisposable
    {
        public override string? PageName { get; set; } = "Other product choice page";

        public OtherProductChoicePage()
        {
            OtherProduct? currentProduct = default;

            using (OtherProductRepository _ = new())
            {
                Task task = _.ReadAsync();
                task.Wait();
            }

            using (OtherProductRepository _ = new())
            {
                Task<OtherProduct> task = _.GetOneAsync();
                task.Wait();
                currentProduct=task.Result;
            }

            int count = TypeConsoleInput.IntValue("Count is", "Invalid value. Try again");

            CurrentOrder=new(currentProduct.ProductType+" "+currentProduct.Producer+" "+currentProduct.Model, currentProduct.Price, count);
        }

        public void Dispose() { }
    }
}