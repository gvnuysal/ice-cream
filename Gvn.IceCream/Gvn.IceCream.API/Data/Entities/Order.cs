using System.ComponentModel.DataAnnotations;

namespace Gvn.IceCream.API.Data.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }
    public DateTime OrderAt { get; set; }
    public Guid CustomerId { get; set; }
    [Required, MaxLength(100)]
    public string CustomerName { get; set; }
    [Required, MaxLength(100)]
    public string CustomerEmail { get; set; }
    [Required, MaxLength(200)]
    public string CustomerAddress { get; set; }
    [Range(0.1,double.MaxValue)]
    public double TotalPrice { get; set; }
    public virtual ICollection<OrderItem> Items { get; set; }
}
