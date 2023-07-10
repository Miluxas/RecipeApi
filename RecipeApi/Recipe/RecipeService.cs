using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Exceptions;
using RecipeApi.Recipe.Models;

namespace RecipeApi.Recipe
{
    public class RecipeService
    {
        private readonly RecipeApiContext _context;

        private readonly IMapper mapper;

        public RecipeService(RecipeApiContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<List<RecipeDetail>> GetList()
        {
            if (_context.Recipe == null)
            {
                throw new NotFoundException();
            }
            var result = await _context.Recipe.ToListAsync();
            return result.Select(mapper.Map<RecipeDetail>).ToList();

        }

        public async Task<RecipeDetail> GetDetail(int id)
        {
            if (_context.Recipe == null)
            {
                throw new NotFoundException();
            }
            var recipe = await _context.Recipe.FindAsync(id);

            if (recipe == null)
            {
                throw new NotFoundException();
            }

            return mapper.Map<RecipeDetail>(recipe);
        }

        public async Task Update(int id, EditRecipe recipe)
        {
            var oldRecipe = await _context.Recipe.FindAsync(id);

            if (oldRecipe == null)
            {
                throw new NotFoundException();
            }
            oldRecipe.Title = recipe.Title;
            oldRecipe.Description = recipe.Description;
            oldRecipe.Instructions = recipe.Instructions;
            oldRecipe.CookingTime = recipe.CookingTime;
            oldRecipe.DifficultyLevel = recipe.DifficultyLevel;
            _context.Entry(oldRecipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<RecipeDetail> Create(NewRecipe recipe)
        {
            if (_context.Recipe == null)
            {
                throw new NotFoundException();

            }
            var newRecipe = new Entities.Recipe();
            newRecipe.Title = recipe.Title;
            newRecipe.Description = recipe.Description;
            newRecipe.Instructions = recipe.Instructions;
            newRecipe.CookingTime = recipe.CookingTime;
            newRecipe.DifficultyLevel = recipe.DifficultyLevel;
            _context.Recipe.Add(newRecipe);
            await _context.SaveChangesAsync();

            return this.mapper.Map<RecipeDetail>(newRecipe);
        }

        public async Task Delete(int id)
        {
            if (_context.Recipe == null)
            {
                throw new NotFoundException();
            }
            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                throw new NotFoundException();
            }

            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();

            throw new NotFoundException();
        }
        public async Task<RecipeDetail> AddIngredient(int recipeId, AddIngredient addIngredient)
        {
            if (_context.Recipe == null)
            {
                throw new NotFoundException();
            }
            var recipe = await _context.Recipe.FindAsync(recipeId);
            if (recipe == null)
            {
                throw new NotFoundException();
            }
            var ingredient = await _context.Ingredient.FindAsync(addIngredient.IngredientId);
            if (ingredient == null)
            {
                throw new NotFoundException();
            }
            var newRecipeIngredient = new Entities.RecipeIngredient();
            newRecipeIngredient.Unit = addIngredient.Unit;
            newRecipeIngredient.Quantity = addIngredient.Quantity;
            newRecipeIngredient.Ingredient = ingredient;
            newRecipeIngredient.RecipeId = recipeId;
            _context.RecipeIngredient.Add(newRecipeIngredient);
            await _context.SaveChangesAsync();

            return this.mapper.Map<RecipeDetail>(recipe);
        }
        public async Task<RecipeDetail> EditIngredient(int recipeId, EditIngredient editIngredient)
        {
            if (_context.RecipeIngredient == null)
            {
                throw new NotFoundException();
            }
            var foundIngredient = await _context.RecipeIngredient.FirstOrDefaultAsync(x=>(x.RecipeId==recipeId && x.Ingredient.Id==editIngredient.IngredientId));
            if (foundIngredient == null)
            {
                throw new NotFoundException();
            }

            foundIngredient.Unit = editIngredient.Unit;
            foundIngredient.Quantity = editIngredient.Quantity;
            _context.Entry(foundIngredient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await this.GetDetail(recipeId);
        }
    }
}
