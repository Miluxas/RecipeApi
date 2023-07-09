using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Exceptions;
using RecipeApi.Ingredient.Models;

namespace RecipeApi.Ingredient
{
    public class IngredientService
    {
        private readonly RecipeApiContext _context;

        private readonly IMapper mapper;

        public IngredientService(RecipeApiContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<List<IngredientDetail>> GetList()
        {
            if (_context.Ingredient == null)
            {
                throw new NotFoundException();
            }
            var result = await _context.Ingredient.ToListAsync();
            return result.Select(mapper.Map<IngredientDetail>).ToList();

        }

        public async Task<IngredientDetail> GetDetail(int id)
        {
            if (_context.Ingredient == null)
            {
                throw new NotFoundException();
            }
            var ingredient = await _context.Ingredient.FindAsync(id);

            if (ingredient == null)
            {
                throw new NotFoundException();
            }

            return mapper.Map<IngredientDetail>(ingredient);
        }

        public async Task Update(int id, EditIngredient ingredient)
        {
            var oldIngredient = await _context.Ingredient.FindAsync(id);

            if (oldIngredient == null)
            {
                throw new NotFoundException();
            }
            oldIngredient.Name = ingredient.Name;
            _context.Entry(oldIngredient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<IngredientDetail> Create(NewIngredient ingredient)
        {
            if (_context.Ingredient == null)
            {
                throw new NotFoundException();

            }
            var newIngredient = new Entities.Ingredient();
            newIngredient.Name=ingredient.Name;
            _context.Ingredient.Add(newIngredient);
            await _context.SaveChangesAsync();

            return this.mapper.Map<IngredientDetail>(newIngredient);
        }

         public async Task Delete(int id)
        {
            if (_context.Ingredient == null)
            {
                throw new NotFoundException();
            }
            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient == null)
            {
                throw new NotFoundException();
            }

            _context.Ingredient.Remove(ingredient);
            await _context.SaveChangesAsync();

            throw new NotFoundException();
        }
    }
}
