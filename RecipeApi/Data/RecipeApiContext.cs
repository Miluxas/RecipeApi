using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Recipe;

namespace RecipeApi.Data
{
    public class RecipeApiContext : DbContext
    {
        public RecipeApiContext (DbContextOptions<RecipeApiContext> options)
            : base(options)
        {
        }

        public DbSet<RecipeApi.Recipe.Recipe> Recipe { get; set; } = default!;
    }
}
