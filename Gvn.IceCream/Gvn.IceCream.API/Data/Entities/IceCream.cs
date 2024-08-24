using System.ComponentModel.DataAnnotations;

namespace Gvn.IceCream.API.Data.Entities;

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
