using System.ComponentModel.DataAnnotations;

namespace Mardul.Recipes.Core.Entities
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [Required]
        public DateTime DateUpdate { get; set; }

    }
}
