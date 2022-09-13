using DiggerScoreClient.Contexts;
using DiggerScoreClient.Interfaces;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Repositories
{
    public sealed class CoilRepository : IDbRepository<Coil>, IDisposable
    {
        public void Create(Coil _)
        {
            using DiggerScoreDbContext db = new();
            db.Coils.Add(_);
            db.SaveChanges();
        }

        public void Delete(int id) { }

        public void Dispose() { }

        public Coil GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Coil GetOne()
        {
            using DiggerScoreDbContext db = new();
            {
                while (true)
                {
                    int id = TypeConsoleInput.IntValue(
                    "Press the item number in the price list for selection", "Invalid value. Try again");

                    if (db.Coils.ToList().Any(_ => _.Id == id))
                    {
                        return db.Coils.ToList().First(_ => _.Id == id);
                    }

                    else Console.WriteLine("No such position exists");
                }
            }
        }

        public async Task<Coil> GetOneAsync() => await Task.Run(() => GetOne());

        public void Read()
        {
            string? titleMessage = "\n<< Search coils >>\n";
            string? postMessage1 =
                "The depth is indicated in centimeters and indicates the increase\n" +
                "relative to the configuration of the device with a standard coil\n";
            string? postMessage2 = "\nThe cost is in dollars at the current exchange rate\n";
            Console.WriteLine(titleMessage);

            using DiggerScoreDbContext db = new();
            db.Coils.ToList().ToConsoleTable(new Dictionary<string, string>
                {
                    {"Id","Id"},
                    {"Type","ProductType" },
                    {"Producer","Producer"},
                    {"Model","Model" },
                    {"Depth","Depth" },
                    {"Additional information","AdditionalInformation" },
                    { "Price","Price"},
                    {"Guarantee","Guarantee" },
                    {"Status","Status" },
                });

            Console.WriteLine(postMessage1 + postMessage2);
        }

        public async Task ReadAsync()
        {
            await Task.Run(() => Read());
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}