using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Contexts;
using DiggerScoreClient.Interfaces;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Repositories
{
    public sealed class CoilRepository :BaseRepository, IRead<Coil>
    { 
        public Coil GetOne()
        {
            using DiggerScoreDbContext db = new();
            {
                Log!.Debug("Coils database access".WithCurrentThreadId());

                while (true)
                {
                    int id = TypeConsoleInput.IntValue(
                    "Press the item number in the price list for selection", "Invalid value. Try again");

                    try
                    {
                        return db.Coils.ToList().First(_ => _.Id == id);
                    }

                    catch (Exception ex)
                    {
                        Log.Warning(ex.Message.WithCurrentThreadId());
                        Console.WriteLine("No such position exists");
                    }
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

            using (DiggerScoreDbContext db = new())
            {
                Log!.Debug("Coils database access".WithCurrentThreadId());

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
            }

            Console.WriteLine(postMessage1 + postMessage2);
        }

        public async Task ReadAsync()
        {
            await Task.Run(() => Read());
        }
    }
}