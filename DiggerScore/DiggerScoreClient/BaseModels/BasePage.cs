using DiggerScoreClient.Services;
using Serilog.Core;

namespace DiggerScoreClient.BaseModels
{
    public abstract class BasePage
    {
        public static Logger Log { get; set; } = LoggerService.GetLogger();

        public virtual string? PageName { get; set; } = "PageNameDefault";
        public ConsoleColor? PageColor { get; set; } = ConsoleColor.DarkYellow;

        public BasePage()
        {
            GetTitle();
            Log.Debug($"Transition to << {PageName} >> in [{Environment.CurrentManagedThreadId}] thread");
        }

        public void GetTitle()
        {
            Console.Clear();
            Console.Title=PageName;
            Console.ForegroundColor=(ConsoleColor)PageColor!;
            Console.WriteLine("----------"+PageName+"----------");
        }
    }
}