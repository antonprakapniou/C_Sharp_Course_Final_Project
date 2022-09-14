using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Repositories;
using DiggerScoreClient.SubModels;
using Validation;

namespace DiggerScoreClient.Pages
{
    public class DiscountConfirmPage:BasePage, IDisposable
    {
        public override string? PageName { get; set; } = "Discount confirm page";

        public byte ConfirmDiscount { get; set; }

        public DiscountConfirmPage()
        {
            PageName="Discount confirm page";
            
            Discount? discount = default;

            using DiscountRepository _ = new();
            discount=_.Get();

            while (true)
            {
                string? inputPromo = TypeConsoleInput.NotEmptyString("Promo is", "Promo cannot be empty. Try again");

                if (discount!.Promo!.Equals(inputPromo))
                {
                    ConfirmDiscount=discount.Value;
                    Console.WriteLine($"Promo code confirmed. Your discount {ConfirmDiscount} %");
                    break;
                }

                else
                {
                    Console.WriteLine(
                        "Invalid promo code value\n" +
                        "Press\n" +
                        "<< 1 >> to try again\n" +
                        "<< other key >> to discount cancel");

                    if (Console.ReadLine()!.Equals("1")) continue;
                    else
                    
                    {
                        ConfirmDiscount=0;
                        Console.WriteLine($"Your discount {ConfirmDiscount} %");
                        break;
                    }
                }
            }
        }

        public void Dispose() { }
    }
}