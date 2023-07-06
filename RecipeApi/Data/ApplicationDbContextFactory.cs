using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<RecipeApiContext>
    {
        public RecipeApiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecipeApiContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new RecipeApiContext(optionsBuilder.Options);
        }
    }
}
