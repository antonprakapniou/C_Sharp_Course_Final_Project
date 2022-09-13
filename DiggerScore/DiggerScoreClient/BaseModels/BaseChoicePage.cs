using DiggerScoreClient.MainModels;

namespace DiggerScoreClient.BaseModels
{
    public class BaseChoicePage:BasePage
    {
        public SingleOrderPosition? CurrentOrder { get; set; }
    }
}