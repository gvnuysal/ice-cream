namespace Gvn.IceCream.API.Data.Entities;

public class IceCreamOptions
{
    public int IcecreamId { get; set; }
    public string Flavor { get; set; }
    public string Topping { get; set; }
    public virtual IceCream Icecream { get; set; }
}
