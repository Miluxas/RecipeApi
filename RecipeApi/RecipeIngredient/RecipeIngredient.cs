using RecipeApi.Ingredient;
using RecipeApi.Recipe;

namespace RecipeApi.RecipeIngredient
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public Recipe.Recipe Recipe { get; set; } = new();
        public Ingredient.Ingredient Ingredient { get; set; } = new();
        public double Quantity { get; set; }
        public string? Unit { get; set; }
        public DateTime CretedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
