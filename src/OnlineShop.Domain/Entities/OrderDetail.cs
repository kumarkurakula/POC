using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

        public List<Product> Product { get; set; }
    }
}