using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Recipe.DTOs
{
    public record CreateRecipeResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public record CreateRecipeRequestBodyDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; } = String.Empty;
    }

}
