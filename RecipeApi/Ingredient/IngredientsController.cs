using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Helper;
using RecipeApi.Ingredient.DTOs;
using RecipeApi.Ingredient.Models;

namespace RecipeApi.Ingredient
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientService service;
        private readonly ExceptionHandler exceptionHnadler;
        private readonly IMapper _mapper;

        public IngredientsController(IMapper mapper, IngredientService service)
        {
            this.service = service;
            exceptionHnadler = new ExceptionHandler(Errors.ErrorDictionary);
            this._mapper = mapper;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetIngredientListResponseDto>>> GetIngredient()
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

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetIngredientDetailResponseDto>> GetIngredient(int id)
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

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, UpdateIngredientRequestBodyDto ingredient)
        {

            try
            {
                await service.Update(id, this._mapper.Map<EditIngredient>(ingredient));
                return Ok();
            }
            catch (Exception exc)
            {
                return exceptionHnadler.Handle(exc);
            }
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateIngredientResponseDto>> PostIngredient(CreateIngredientRequestBodyDto ingredient)
        {
            try
            {
                var newIngredient = await service.Create(_mapper.Map<NewIngredient>(ingredient));

                return CreatedAtAction("GetIngredient", new { id = newIngredient.Id }, newIngredient);
            }
            catch (Exception exc)
            {
                return exceptionHnadler.Handle(exc);
            }
        }




        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
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
