using DiggerScoreClient.BaseModels;
using DiggerScoreClient.MainModels;

namespace DiggerScoreClient.Pages
{
    public sealed class OrderСompletionPage:BasePage, IDisposable
    {
        public List<SingleOrderPosition>? CurrentOrderList { get; set; }

        public OrderСompletionPage()
        {
            PageName = "Order completion page";
            
            CurrentOrderList=new();

            while (true)
            {
                Console.WriteLine(
                "\nPress to choice\n" +
                "<< 1 >> metal detector\n" +
                "<< 2 >> coil\n" +
                "<< other key >> other product");

                string? inputAnswer = Console.ReadLine();

                if (inputAnswer!.Equals("1"))
                {
                    using (MetalDetectorChoicePage _ = new())
                    {
                        CurrentOrderList!.Add(_.CurrentOrder!);
                    }

                }

                else if (inputAnswer!.Equals("2"))
                {
                    using (CoilChoicePage _ = new())
                    {
                        CurrentOrderList!.Add(_.CurrentOrder!);
                    }
                }

                else
                {
                    using (OtherProductChoicePage _ = new())
                    {
                        CurrentOrderList!.Add(_.CurrentOrder!);
                    }
                }

                Console.WriteLine(
                    "\nPress\n" +
                    "<< 1 >> to confirm\n" +
                    "<< other key >> to add more");
                if (Console.ReadLine()!.Equals("1")) break;
            }
        }

        public void Dispose() { }
    }
}