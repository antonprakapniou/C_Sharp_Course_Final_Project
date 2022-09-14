using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Repositories;
using Validation;

namespace DiggerScoreClient.Pages
{
    public sealed class ShoppingPage:BasePage,IDisposable
    {
        public override string? PageName { get; set; } = "Shopping page";

        public ShoppingPage()
        {
            ReceivingPage _ = new();

            _.TrueOrderList!.UpdateById().ToConsoleTable(
                   new Dictionary<string, string>
                   {
                        { "Id","Id"},
                        { "Full name","FullName"},
                        { "Price","Price"},
                        { "Count","Count"},
                   });

            Console.WriteLine(
                $"Total amount is {_.TrueTotalAmount} $\n" +
                $"Discount is {_.TrueDiscount} %\n" +
                $"To pay {_.TrueDiscountAmount} $");

            using (OrderActionHistoryRepository rep = new())
            {
                foreach (var item in _.TrueOrderList!)
                    rep.Create(new($"{_.TrueUser!.Name} {_.TrueUser.Login}",$"ordered {item.FullName} in quantity {item.Count}"));
            }

            Console.WriteLine("Press << Escape >> to leave this page");
            while (Console.ReadKey().Key!=ConsoleKey.Escape) { }
        }

        public void Dispose() { }
    }
}