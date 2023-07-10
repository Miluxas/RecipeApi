namespace RecipeApi.User
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Recipe.Entities.Recipe> Favorites { get; } = new();
        public List<Rating.Rating> Ratings { get; } = new();

    }
}
