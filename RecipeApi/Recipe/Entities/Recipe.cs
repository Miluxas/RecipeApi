namespace RecipeApi.Recipe.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Instructions { get; set; }
        public int CookingTime { get; set; }
        public int DifficultyLevel { get; set; }
        public List<RecipeIngredient.RecipeIngredient> RecipeIngredients { get; } = new();
        public List<Rating.Rating> Ratings { get; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
