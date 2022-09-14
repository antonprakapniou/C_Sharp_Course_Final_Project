using DiggerScoreClient.BaseModels;
using DiggerScoreClient.MainModels;

namespace DiggerScoreClient.Pages
{
    public sealed class ReceivingPage:BasePage, IDisposable
    {
        public override string? PageName { get; set; } = "Receiving page";

        public User? TrueUser { get; set; }
        public List<SingleOrderPosition>? TrueOrderList { get; set; }
        public byte TrueDiscount { get; set; }
        public double TrueTotalAmount { get; set; }
        public double TrueDiscountAmount { get; set; }

        public ReceivingPage()
        {
            TrueUser=new AuthorizationPage().CurrentUser;
            TrueOrderList=new OrderConfirmationPage().ConfirmOrderList;
            TrueDiscount=new DiscountConfirmPage().ConfirmDiscount;

            foreach (var item in TrueOrderList!) TrueTotalAmount+=item.Price*item.Count;

            TrueDiscountAmount=TrueTotalAmount*(100-TrueDiscount)*0.01;
        }

        public void Dispose() { }
    }
}