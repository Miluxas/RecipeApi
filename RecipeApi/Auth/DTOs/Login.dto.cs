using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Auth.DTOs
{
    public record LoginResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public record LoginRequestBodyDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Username { get; set; } = String.Empty;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Password { get; set; } = String.Empty;
    }

}
