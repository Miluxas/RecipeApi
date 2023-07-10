namespace RecipeApi.Recipe.Entities
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Ingredient.Entities.Ingredient Ingredient { get; set; } = new();
        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public DateTime CretedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
