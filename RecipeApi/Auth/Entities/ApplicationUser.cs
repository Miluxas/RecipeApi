
using Microsoft.AspNetCore.Identity;
using RecipeApi.Recipe.Entities;

namespace RecipeApi.Auth.Entities
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string? Name { get; set; }
        public List<Recipe.Entities.Recipe> Favorites { get; } = new();
        public List<Rating> Ratings { get; } = new();
    }
}
