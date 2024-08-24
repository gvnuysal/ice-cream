using System.ComponentModel.DataAnnotations;

namespace Gvn.IceCream.API.Data.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required,MaxLength(30)]
    public string Name { get; set; }
    [Required, MaxLength(100)]   
    public string Email { get; set; }
    [Required, MaxLength(200)]
    public string Address { get; set; }
    public string Salt { get; set; }
    public string Hash { get; set; }
}
public class IceCream
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(200)]
    public string Name { get; set; }
    [Range(0.1,double.MaxValue)]
    public double Price { get; set; }
    [Required, MaxLength(200)]
    public string Image { get; set; }
    public virtual ICollection<IceCreamOptions> Options { get; set; }

}
public class IceCreamOptions
{
    public int IcecreamId { get; set; }
    public string Flavor { get; set; }
    public string Topping { get; set; }
    public virtual IceCream Icecream { get; set; }
}
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
public class OrderItem
{
    [Key]
    public long Id { get; set; }
    public long OrderId { get; set; }
    public int IcecreamId { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Range(0.1, double.MaxValue)]
    public double Price { get; set; }
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    public string Flavor { get; set; }
    public string Topping { get; set; }
    [Range(0.1, double.MaxValue)]
    public double TotalPrice { get; set; }
    public virtual Order Order { get; set; }
}