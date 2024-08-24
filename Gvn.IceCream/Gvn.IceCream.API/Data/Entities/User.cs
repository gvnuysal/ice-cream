using System.ComponentModel.DataAnnotations;

namespace Gvn.IceCream.API.Data.Entities
{
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
}
