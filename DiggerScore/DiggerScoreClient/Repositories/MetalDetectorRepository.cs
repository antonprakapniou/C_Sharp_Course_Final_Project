using DiggerScoreClient.Contexts;
using DiggerScoreClient.Interfaces;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Repositories
{
    public sealed class MetalDetectorRepository : IDbRepository<MetalDetector>, IDisposable
    {
        public void Create(MetalDetector _)
        {
            using DiggerScoreDbContext db = new();
            db.MetalDetectors.Add(_);
            db.SaveChanges();
        }

        public void Delete(int id) { }

        public MetalDetector GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MetalDetector GetOne()
        {
            using DiggerScoreDbContext db = new();
            {
                while (true)
                {
                    int id = TypeConsoleInput.IntValue(
                    "Press the item number in the price list for selection", "Invalid value. Try again");

                    if (db.MetalDetectors.ToList().Any(_ => _.Id == id))
                    {
                        return db.MetalDetectors.ToList().First(_ => _.Id == id);
                    }

                    else Console.WriteLine("No such position exists. Try again");
                }
            }
        }

        public async Task<MetalDetector> GetOneAsync()
        {
            await Task.Delay(0);
            return GetOne();
        }

        public void Read()
        {
            string? titleMessage = "\n<< Metal detectors >>\n";
            string? postMessage1 =
                "\nThe depth is indicated in centimeters, achieved by a standard coil\n" +
                "for an object like 5 kopecks of Catherine II in the air\n";
            string? postMessage2 = "\nThe cost is in dollars at the current exchange rate\n";
            Console.WriteLine(titleMessage);

            using DiggerScoreDbContext db = new();
            db.MetalDetectors.ToList().ToConsoleTable(new Dictionary<string, string>
                {
                    { "Id", "Id" },
                    {"Type","ProductType" },
                    { "Producer", "Producer" },
                    {"Model","Model" },
                    {"Level","Level" },
                    {"Standart coil","StandartCoil" },
                    {"Depth","StandartDepth" },
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

        public void Update(int id) { }

        void IDisposable.Dispose() { }
    }
}