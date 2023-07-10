using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Recipe.DTOs
{
    public record UpdateRecipeRequestBodyDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }=String.Empty;
        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public string Description { get; set; } = String.Empty;
        [Required]
        [StringLength(3000, MinimumLength = 3)]
        public string Instructions { get; set; } = String.Empty;
        [Required]
        public int CookingTime { get; set; }
        [Required]
        public int DifficultyLevel { get; set; }
    }

}
