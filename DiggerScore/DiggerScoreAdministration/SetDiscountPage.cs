using System.Text.Json;
using Validation;

namespace DiggerScoreAdministration
{
    public class SetDiscountPage:IDisposable
    {
        public Discount? TrueDiscount { get; set; }

        public SetDiscountPage()
        {
            Console.Clear();
            Console.Title="Set discount page";

            string? connectionString = @"D:\DiggerScoreAdministration\DiggerScoreAdministration\.json\Discount.json";

            using (FileStream _ = new FileStream(connectionString, FileMode.OpenOrCreate))
            {
                TrueDiscount = JsonSerializer.Deserialize<Discount>(_);
            }

            Console.WriteLine($"Previos promo code is << {TrueDiscount!.Promo} >>");
            TrueDiscount.Promo=TypeConsoleInput.NotEmptyString("New promo code","Ptomo code can not be empty");

            Console.WriteLine($"Previos discount is << {TrueDiscount!.Value} >>");
            TrueDiscount.Value=TypeConsoleInput.ByteValue("New discount is", "Invalid value.Try again");

            using (StreamWriter _ = new(connectionString, false)) { }

            using (FileStream _=new(connectionString,FileMode.Create))
            {
                JsonSerializer.Serialize<Discount>(_, TrueDiscount);
            }
        }

        public void Dispose() { }
    }
}