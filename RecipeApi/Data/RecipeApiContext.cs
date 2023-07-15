using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Auth.Entities;
using RecipeApi.Recipe.Entities;

namespace RecipeApi.Data
{
    public class RecipeApiContext : IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
    {
        public RecipeApiContext (DbContextOptions<RecipeApiContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe.Entities.Recipe> Recipe { get; set; } = default!;
        public DbSet<Ingredient.Entities.Ingredient> Ingredient { get; set; } = default!;
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; } = default!;
        public DbSet<Rating> Rating { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
