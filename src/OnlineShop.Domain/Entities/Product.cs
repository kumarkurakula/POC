using OnlineShop.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public int CategoryId { get; set; }
    }
}