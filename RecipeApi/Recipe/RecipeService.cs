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
            var ingredient = await _context.Recipe.FindAsync(id);

            if (ingredient == null)
            {
                throw new NotFoundException();
            }

            return mapper.Map<RecipeDetail>(ingredient);
        }

        public async Task Update(int id, EditRecipe ingredient)
        {
            var oldRecipe = await _context.Recipe.FindAsync(id);

            if (oldRecipe == null)
            {
                throw new NotFoundException();
            }
            oldRecipe.Title = ingredient.Title;
            oldRecipe.Description = ingredient.Description;
            oldRecipe.Instructions = ingredient.Instructions;
            oldRecipe.CookingTime = ingredient.CookingTime;
            oldRecipe.DifficultyLevel = ingredient.DifficultyLevel;
            _context.Entry(oldRecipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<RecipeDetail> Create(NewRecipe ingredient)
        {
            if (_context.Recipe == null)
            {
                throw new NotFoundException();

            }
            var newRecipe = new Entities.Recipe();
            newRecipe.Title=ingredient.Title;
            newRecipe.Description = ingredient.Description;
            newRecipe.Instructions = ingredient.Instructions;
            newRecipe.CookingTime = ingredient.CookingTime;
            newRecipe.DifficultyLevel = ingredient.DifficultyLevel;
            await _context.SaveChangesAsync();

            return this.mapper.Map<RecipeDetail>(newRecipe);
        }

         public async Task Delete(int id)
        {
            if (_context.Recipe == null)
            {
                throw new NotFoundException();
            }
            var ingredient = await _context.Recipe.FindAsync(id);
            if (ingredient == null)
            {
                throw new NotFoundException();
            }

            _context.Recipe.Remove(ingredient);
            await _context.SaveChangesAsync();

            throw new NotFoundException();
        }
    }
}
