namespace DiggerScoreAdministration
{
    public sealed class Discount
    {
        public string?Promo { get; set; }
        public byte Value { get; set; }

        public Discount(string? promo, byte value)
        {
            Promo=promo;
            Value=value;
        }
    }
}