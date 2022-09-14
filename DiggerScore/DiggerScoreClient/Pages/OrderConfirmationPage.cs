using DiggerScoreClient.BaseModels;
using DiggerScoreClient.MainModels;
using Validation;

namespace DiggerScoreClient.Pages
{
    public sealed class OrderConfirmationPage:BasePage, IDisposable
    {
        public override string? PageName { get; set; } = "Order confirmation page";

        public List<SingleOrderPosition>? ConfirmOrderList { get; set; }

        public OrderConfirmationPage()
        {
            ConfirmOrderList=new();

            while(true)
            {
                Console.WriteLine("It's your order");
                OrderСompletionPage _=new();
                _.CurrentOrderList!.UpdateById().ToConsoleTable(
                    new Dictionary<string, string>
                    {
                        { "Id","Id"},
                        { "Full name","FullName"},
                        { "Price","Price"},
                        { "Count","Count"},
                    });

                Console.WriteLine(
                    "Press\n" +
                    "<< 1 >> to confirm it\n" +
                    "<< other key >> to change");

                if (Console.ReadLine()!.Equals("1"))
                {
                    ConfirmOrderList = _.CurrentOrderList;
                    break;
                }
            }
        }

        public void Dispose() { }
    }
}