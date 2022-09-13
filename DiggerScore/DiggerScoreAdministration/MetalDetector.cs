namespace DiggerScoreAdministration
{
    public sealed class MetalDetector:BaseProduct
    {
        public override string? ProductType { get; set; } = "Metal detector";
        public override byte Guarantee { get; set; } = 2;
        public LevelEnum Level { get; set; }
        public double StandartDepth { get; set; }
        public string? StandartCoil { get; set; }

        public MetalDetector(string? producer, string? model, LevelEnum level, string? standartCoil, double standartDepth, double price, string? additionalInformation, StatusEnum status)
        {
            Producer = producer;
            Model = model;
            Level = level;
            StandartCoil = standartCoil;
            StandartDepth = standartDepth;
            Price = price;
            AdditionalInformation = additionalInformation;
            Status = status;
        }

        [Flags]
        public enum LevelEnum
        {
            other = 0,
            newbie = 0b1,
            middle = 0b1_0,
            professional = 0b1_00,
            all = 0b1_000,
        }
    }
}