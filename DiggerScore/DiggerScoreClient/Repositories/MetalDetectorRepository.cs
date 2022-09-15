using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Contexts;
using DiggerScoreClient.Interfaces;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Repositories
{
    public sealed class MetalDetectorRepository :BaseRepository, IRead<MetalDetector>
    {
        public MetalDetector GetOne()
        {
            using DiggerScoreDbContext db = new();
            {
                Log!.Debug("Metal detector database access ".WithCurrentThreadId());

                while (true)
                {
                    int id = TypeConsoleInput.IntValue(
                    "Press the item number in the price list for selection", "Invalid value. Try again");

                    try
                    {
                        return db.MetalDetectors.ToList().First(_ => _.Id == id);
                    }

                    catch (Exception ex)
                    {
                        Log.Warning(ex.Message.WithCurrentThreadId());
                        Console.WriteLine("No such position exists");
                    }
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
            {
                Log!.Debug("Metal detector database access".WithCurrentThreadId());

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
            }
            

            Console.WriteLine(postMessage1 + postMessage2);
        }

        public async Task ReadAsync()
        {
            await Task.Run(() => Read());  
        }
    }
}