using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Contexts;
using DiggerScoreClient.Interfaces;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Repositories
{
    public sealed class OtherProductRepository :BaseRepository, IRead<OtherProduct>
    {
        public OtherProduct GetOne()
        {
            using DiggerScoreDbContext db = new();
            {
                Log!.Debug("Other product database access".WithCurrentThreadId());

                while (true)
                {
                    int id = TypeConsoleInput.IntValue(
                    "Press the item number in the price list for selection", "Invalid value. Try again");

                    try
                    {
                        return db.OtherProducts.ToList().First(_ => _.Id == id);
                    }

                    catch (Exception ex)
                    {
                        Log.Warning(ex.Message.WithCurrentThreadId());
                        Console.WriteLine("No such position exists");
                    }
                }
            }
        }

        public async Task<OtherProduct> GetOneAsync() => await Task.Run(() => GetOne());

        public void Read()
        {
            string? titleMessage = "\n<< Other products >>\n";
            string? postMessage = "\nThe cost is in dollars at the current exchange rate\n";
            Console.WriteLine(titleMessage);

            using (DiggerScoreDbContext db = new())
            {
                Log!.Debug("Other product database access".WithCurrentThreadId());

                db.OtherProducts.ToList().ToConsoleTable(new Dictionary<string, string>
                {
                    { "Id", "Id" },
                    {"Type","ProductType" },
                    { "Producer", "Producer" },
                    {"Model","Model" },
                    {"Additional information","AdditionalInformation" },
                    { "Price","Price"},
                    {"Guarantee","Guarantee" },
                    {"Status","Status" },
                });
            }

            Console.WriteLine(postMessage);
        }

        public async Task ReadAsync()
        {
            await Task.Run(() => Read());
        }
    }
}