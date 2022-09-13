using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Repositories;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Pages
{
    public sealed class MetalDetectorChoicePage:BaseChoicePage,IDisposable
    {
        public MetalDetectorChoicePage()
        {
            PageName="Metal detector choice page";

            MetalDetector? currentProduct = default;

            using (MetalDetectorRepository _=new())
            {
                Task task = _.ReadAsync();
                task.Wait();
            }

            using (MetalDetectorRepository _ = new())
            {
                Task<MetalDetector> task = _.GetOneAsync();
                task.Wait();
                currentProduct=task.Result;
            }

            int count = TypeConsoleInput.IntValue("Count is", "Invalid value. Try again");

            CurrentOrder=new(currentProduct.ProductType+" "+currentProduct.Producer+" "+currentProduct.Model, currentProduct.Price,count);
        }

        public void Dispose() { }
    }
}