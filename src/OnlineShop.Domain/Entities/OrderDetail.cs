namespace OnlineShop.Domain.Entities
{
    public class OrderDetail
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public Order Orders { get; set; }
        public Product Product { get; set; }
    }
}