namespace RecipeApi.Rating
{
    public class Rating
    {
        public int Id { get; set; }
        public User.User User { get; set; } = new();
        public Recipe.Entities.Recipe Recipe { get; set; } = new();
        public int RatingValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
