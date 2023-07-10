using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Ingredient;
using RecipeApi.Recipe;
using System.Reflection;

namespace RecipeApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RecipeApiContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RecipeApiContext"),
                b => b.MigrationsAssembly(typeof(RecipeApiContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddScoped<IngredientService, IngredientService>();
            services.AddScoped<RecipeService, RecipeService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}