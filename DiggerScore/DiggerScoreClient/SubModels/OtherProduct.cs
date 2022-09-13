using DiggerScoreClient.BaseModels;

namespace DiggerScoreClient.SubModels
{
    public sealed class OtherProduct : BaseProduct
    {
        public override string? ProductType { get; set; } = "Other Product";

        public OtherProduct(string? productType, string? producer, string? model, double price, string? additionalInformation, byte guarantee, StatusEnum status)
        {
            ProductType = productType;
            Producer = producer;
            Model = model;
            Price = price;
            AdditionalInformation = additionalInformation;
            Guarantee = guarantee;
            Status = status;
        }
    }
}