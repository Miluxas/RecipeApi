using AutoMapper;
using RecipeApi.Recipe.DTOs;
using RecipeApi.Recipe.Models;

namespace RecipeApi.Recipe
{
    public class ToDoMapper : Profile
    {
        public ToDoMapper()
        {
            CreateMap<UpdateRecipeRequestBodyDto, EditRecipe>();
            CreateMap<CreateRecipeRequestBodyDto, NewRecipe>();
            CreateMap<RecipeDetail, UpdateRecipeResponseDto>();
            CreateMap<RecipeDetail, CreateRecipeResponseDto>();
            CreateMap<Entities.Recipe, RecipeDetail>();
        }
    }
}
