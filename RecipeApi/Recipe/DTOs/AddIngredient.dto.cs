using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Recipe.DTOs
{
    public record AddIngredientRequestBodyDto
    {
        [Required]
        public int IngredientId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Unit { get; set; } = string.Empty;
    }

}
