using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Helper;
using RecipeApi.Recipe.DTOs;
using RecipeApi.Recipe.Models;

namespace RecipeApi.Recipe
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeService service;
        private readonly ExceptionHandler exceptionHnadler;
        private readonly IMapper _mapper;

        public RecipesController(IMapper mapper, RecipeService service)
        {
            this.service = service;
            exceptionHnadler = new ExceptionHandler(Errors.ErrorDictionary);
            this._mapper = mapper;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRecipeListResponseDto>>> GetRecipe()
        {
            try
            {
                return Ok(await this.service.GetList());
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return exceptionHnadler.Handle(exc);
            }

        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRecipeDetailResponseDto>> GetRecipe(int id)
        {
            try
            {
                return Ok(await this.service.GetDetail(id));
            }
            catch (Exception exc)
            {
                return exceptionHnadler.Handle(exc);
            }
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, UpdateRecipeRequestBodyDto recipe)
        {

            try
            {
                await service.Update(id, this._mapper.Map<EditRecipe>(recipe));
                return Ok();
            }
            catch (Exception exc)
            {
                return exceptionHnadler.Handle(exc);
            }
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetRecipeDetailResponseDto>> PostRecipe(CreateRecipeRequestBodyDto recipe)
        {
            try
            {
                var newRecipe = await service.Create(_mapper.Map<NewRecipe>(recipe));

                return CreatedAtAction("GetRecipe", new { id = newRecipe.Id }, newRecipe);
            }
            catch (Exception exc)
            {
                return exceptionHnadler.Handle(exc);
            }
        }

        [HttpPost("{id}/ingredients")]
        public async Task<ActionResult<GetRecipeDetailResponseDto>> AddIngredient(int id,AddIngredientRequestBodyDto newIngredient)
        {
            try
            {
                var recipe = await service.AddIngredient(id,_mapper.Map<AddIngredient>(newIngredient));

                return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
            }
            catch (Exception exc)
            {
                return exceptionHnadler.Handle(exc);
            }
        }


        [HttpPut("{id}/ingredients")]
        public async Task<ActionResult<GetRecipeDetailResponseDto>> EditIngredient(int id,EditIngredientRequestBodyDto oldIngredient)
        {
            try
            {
                var recipe = await service.EditIngredient(id, _mapper.Map<EditIngredient>(oldIngredient));

                return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
            }
            catch (Exception exc)
            {
                return exceptionHnadler.Handle(exc);
            }
        }




        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            try
            {
                await this.service.Delete(id);
                return NoContent();
            }
            catch (Exception exc)
            {
                return exceptionHnadler.Handle(exc);
            }
        }
    }
}
