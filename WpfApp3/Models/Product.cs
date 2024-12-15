namespace StationeryInventory.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
