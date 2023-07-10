using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Recipe.Entities;

namespace RecipeApi.Data
{
    public class RecipeApiContext : DbContext
    {
        public RecipeApiContext (DbContextOptions<RecipeApiContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe.Entities.Recipe> Recipe { get; set; } = default!;
        public DbSet<Ingredient.Entities.Ingredient> Ingredient { get; set; } = default!;
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; } = default!;
    }
}
