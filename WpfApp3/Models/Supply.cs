namespace StationeryInventory.Models
{
    public class Supply
    {
        public int SupplyId { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public DateTime SupplyDate { get; set; }
        public int Quantity { get; set; }
    }
}
