namespace MVC_Challenge.Models
{
    public enum EntityTypeOption
    {
        Property,
        vehicles,
        land,
        apartments
    }
    public enum EntityStatus
    {
        Inactivo = 0,
        Activo = 1
    }
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public EntityTypeOption Type { get; set; }
        public Decimal Value { get; set; }
        public DateTime DatePurchase { get; set; }
        public EntityStatus Status { get; set; }
    }
}
