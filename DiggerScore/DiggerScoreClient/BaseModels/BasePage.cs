using DiggerScoreClient.Services;
using Serilog.Core;
using Validation;

namespace DiggerScoreClient.BaseModels
{
    public abstract class BasePage:BaseClass
    {
        public virtual string? PageName { get; set; } = "PageNameDefault";
        public ConsoleColor? PageColor { get; set; } = ConsoleColor.DarkYellow;

        public BasePage()
        {
            GetTitle();
            Log!.Debug($"Transition to << {PageName} >>".WithCurrentThreadId());
        }

        public void GetTitle()
        {
            Console.Clear();
            Console.Title=PageName!;
            Console.ForegroundColor=(ConsoleColor)PageColor!;
            Console.WriteLine("----------"+PageName+"----------");
        }
    }
}