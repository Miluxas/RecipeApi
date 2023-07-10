namespace RecipeApi.Recipe.Models
{
    public record EditRecipe
    {
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Instructions { get; set; } = String.Empty;
        public int CookingTime { get; set; }
        public int DifficultyLevel { get; set; }
    }
}
