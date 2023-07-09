using AutoMapper;
using RecipeApi.Ingredient.DTOs;
using RecipeApi.Ingredient.Models;

namespace RecipeApi.Ingredient
{
    public class ToDoMapper : Profile
    {
        public ToDoMapper()
        {
            CreateMap<UpdateIngredientRequestBodyDto, EditIngredient>();
            CreateMap<CreateIngredientRequestBodyDto, NewIngredient>();
            CreateMap<IngredientDetail, UpdateIngredientResponseDto>();
            CreateMap<IngredientDetail, CreateIngredientResponseDto>();
            CreateMap<Entities.Ingredient, IngredientDetail>();
        }
    }
}
