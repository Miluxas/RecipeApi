namespace RecipeApi.Ingredient.DTOs
{
    public record GetIngredientDetailResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
