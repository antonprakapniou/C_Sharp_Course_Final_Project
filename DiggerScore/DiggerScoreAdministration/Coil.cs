namespace DiggerScoreAdministration
{
    public sealed class Coil:BaseProduct
    {
        public override string? ProductType { get; set; } = "Detection coil";
        public override byte Guarantee { get; set; } = 1;
        public double Depth { get; set; }

        public Coil(string? producer, string? model, double depth, double price, string? additionalInformation, StatusEnum status)
        {
            Producer=producer;
            Model=model;
            Depth=depth;
            Price=price;
            AdditionalInformation=additionalInformation;
            Status=status;
        }
    }
}