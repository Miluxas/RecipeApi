namespace RecipeApi.Recipe.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public Auth.Entities.ApplicationUser User { get; set; } = new();
        public int RecipeId { get; set; }
        public int RatingValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
