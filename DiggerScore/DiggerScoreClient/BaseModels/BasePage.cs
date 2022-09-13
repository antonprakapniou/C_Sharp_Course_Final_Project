namespace DiggerScoreClient.BaseModels
{
    public abstract class BasePage
    {
        public string? PageName { get; set; } = "PageNameDefault";
        public ConsoleColor? Color { get; set; } = ConsoleColor.DarkYellow;

        public BasePage()
        {
            GetTitle();
        }

        public void GetTitle()
        {
            Console.Clear();
            Console.Title=PageName!;
            Console.WriteLine("----------"+PageName+"----------");
        }
    }
}