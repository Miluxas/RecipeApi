using RecipeApi.Recipe.Entities;

namespace RecipeApi.Recipe.Models
{
    public record RecipeDetail
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Instructions { get; set; } = String.Empty;
        public int CookingTime { get; set; }
        public int DifficultyLevel { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; } = new();
        public List<Rating.Rating> Ratings { get; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
