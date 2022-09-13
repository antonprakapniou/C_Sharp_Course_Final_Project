using DiggerScoreClient.Contexts;
using DiggerScoreClient.Interfaces;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Repositories
{
    public sealed class OtherProductRepository : IDbRepository<OtherProduct>, IDisposable
    {
        public void Create(OtherProduct _) { }

        public void Delete(int id) { }

        public OtherProduct GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OtherProduct GetOne()
        {
            using DiggerScoreDbContext db = new();
            {
                while (true)
                {
                    int id = TypeConsoleInput.IntValue(
                    "Press the item number in the price list for selection", "Invalid value. Try again");

                    if (db.OtherProducts.ToList().Any(_ => _.Id == id))
                    {
                        return db.OtherProducts.ToList().First(_ => _.Id == id);
                    }

                    else Console.WriteLine("No such position exists. Try again");
                }
            }
        }

        public async Task<OtherProduct> GetOneAsync() => await Task.Run(() => GetOne());

        public void Read()
        {
            string? titleMessage = "\n<< Other products >>\n";
            string? postMessage = "\nThe cost is in dollars at the current exchange rate\n";
            Console.WriteLine(titleMessage);

            using DiggerScoreDbContext db = new();
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

            Console.WriteLine(postMessage);
        }

        public async Task ReadAsync()
        {
            await Task.Run(() => Read());
        }

        public void Update(int id) { }

        void IDisposable.Dispose() { }
    }
}