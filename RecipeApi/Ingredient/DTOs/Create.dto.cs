using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Ingredient.DTOs
{
    public record CreateIngredientResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public record CreateIngredientRequestBodyDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; } = String.Empty;
    }

}
