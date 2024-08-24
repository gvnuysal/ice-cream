using Gvn.IceCream.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gvn.IceCream.API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Gvn.IceCream.API.Data.Entities.IceCream> IceCreams { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<IceCreamOptions> IceCreamOptions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IceCreamOptions>().HasKey(io => new { io.IcecreamId, io.Flavor, io.Topping });

        base.OnModelCreating(modelBuilder);
    }
    private static void AddSeedData(ModelBuilder modelBuilder)
    {
        //https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_0.jpg
        Entities.IceCream[] iceCreams = new Entities.IceCream[]
        {
            new(){
                Id = 1,
                Name = "Vanilla Delight",
                Price = 1.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_0.jpg"
            },
            new(){
                Id = 2,
                Name = "Chocolate Heaven",
                Price = 2.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_1.jpg"
            },
            new(){
                Id = 3,
                Name = "Strawberry Dream",
                Price = 3.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_2.jpg"
            },
            new(){
                Id = 4,
                Name = "Mint Chocolate Chip",
                Price = 4.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_3.jpg"
            },
            new(){
                Id = 5,
                Name = "Cookies and Cream",
                Price = 5.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_4.jpg"
            },
            new(){
                Id = 6,
                Name = "Butter Pecan",
                Price = 6.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_5.jpg"
            },
            new(){
                Id = 7,
                Name = "Rocky Road",
                Price = 7.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_6.jpg"
            },
            new(){
                Id = 8,
                Name = "Pistachio",
                Price = 8.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_7.jpg"
            },
            new(){
                Id = 9,
                Name = "Neapolitan",
                Price = 9.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_8.jpg"
            },
            new(){
                Id = 10,
                Name = "Birthday Cake",
                Price = 10.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_9.jpg"
            }, 
            new(){
                Id = 11,
                Name = "Birthday Cake",
                Price = 10.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_10.jpg"
            },
            new(){
                Id = 12,
                Name = "Birthday Cake",
                Price = 10.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_11.jpg"
            },
            new(){
                Id = 13,
                Name = "Birthday Cake",
                Price = 10.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_12.jpg"
            },
            new(){
                Id = 14,
                Name = "Birthday Cake",
                Price = 10.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_13.jpg"
            },
            new(){
                Id = 15,
                Name = "Birthday Cake",
                Price = 10.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_14.jpg"
            },
            new(){
                Id = 16,
                Name = "Bluee bake Cake",
                Price = 10.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_15.jpg"
            },
            new(){
                Id = 17,
                Name = "Bluee bake Cake",
                Price = 10.5,
                Image = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/main/Icecreams/small/ic_16.jpg"
            },
        };
        IceCreamOptions[] iceCreamOptions = new IceCreamOptions[] {
            new() { IcecreamId = 1, Flavor = "Vanilla", Topping = "Default" },
            new() { IcecreamId = 1, Flavor = "Default", Topping = "Chocolate Sauce" },
            new() { IcecreamId = 2, Flavor = "Chocolate", Topping = "Default" },
            new() { IcecreamId = 2, Flavor = "Strawbery", Topping = "Whipped" },
            new() { IcecreamId = 2, Flavor = "Chocolate", Topping = "Default" },
            new() { IcecreamId = 3, Flavor = "Strawberry", Topping = "Default" },
            new() { IcecreamId = 4, Flavor = "Mint", Topping = "Default" },
            new() { IcecreamId = 5, Flavor = "Cookies", Topping = "Default" },
            new() { IcecreamId = 6, Flavor = "Butter", Topping = "Default" },
            new() { IcecreamId = 7, Flavor = "Rocky", Topping = "Default" },
            new() { IcecreamId = 8, Flavor = "Pistachio", Topping = "Default" },
            new() { IcecreamId = 9, Flavor = "Neapolitan", Topping = "Default" },
        };
        modelBuilder.Entity<Entities.IceCream>().HasData(iceCreams);
        modelBuilder.Entity<IceCreamOptions>().HasData(iceCreamOptions);
    }
}
