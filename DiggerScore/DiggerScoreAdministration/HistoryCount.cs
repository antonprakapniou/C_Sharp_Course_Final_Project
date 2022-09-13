namespace DiggerScoreAdministration
{
    public class HistoryCount
    {
        public int OrderHistoryCount { get; set; }
        public int UserHistoryCount { get; set; }

        public HistoryCount(int orderHistoryCount, int userHistoryCount)
        {
            OrderHistoryCount=orderHistoryCount;
            UserHistoryCount=userHistoryCount;
        }
    }
}