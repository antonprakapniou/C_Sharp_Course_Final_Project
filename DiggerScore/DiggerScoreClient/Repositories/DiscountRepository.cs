using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Interfaces;
using DiggerScoreClient.SubModels;
using System.Text.Json;
using Validation;

namespace DiggerScoreClient.Repositories
{
    public class DiscountRepository : BaseRepository,IRead<Discount>
    {
        public Discount GetOne()
        {            
            using (FileStream fs = new FileStream(@"D:\GitHubRepositories\C_Sharp_Course_Final_Project\DiggerScore\DiggerScoreAdministration\.json\Discount.json", FileMode.OpenOrCreate))
            {
                Log!.Debug("Discount database access".WithCurrentThreadId());
                return JsonSerializer.Deserialize<Discount>(fs)!;
            }
        }

        public void Read() { }//empty
    }
}