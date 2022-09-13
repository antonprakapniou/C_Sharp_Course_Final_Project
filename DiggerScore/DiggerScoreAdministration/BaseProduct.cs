namespace DiggerScoreAdministration
{
    public abstract class BaseProduct
    {
        public virtual string? ProductType { get; set; }
        public virtual byte Guarantee { get; set; }

        public int Id { get; set; }
        public string? Producer { get; set; }
        public string? Model { get; set; }
        public string? AdditionalInformation { get; set; }
        public double Price { get; set; }
        public StatusEnum Status { get; set; }

        public enum StatusEnum
        {
            in_stock = 0,
            on_order = 1,
            other = 2,
        }
    }
}