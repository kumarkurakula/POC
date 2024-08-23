using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
