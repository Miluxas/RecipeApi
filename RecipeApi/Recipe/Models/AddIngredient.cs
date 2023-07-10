namespace RecipeApi.Recipe.Models
{
    public record AddIngredient
    {
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; } = String.Empty;
    }
}
