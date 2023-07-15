using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Auth.DTOs;
using RecipeApi.Helper;

namespace RecipeApi.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService service;
        private readonly ExceptionHandler exceptionHnadler;
        private readonly IMapper _mapper;

        public AuthController(IMapper mapper, AuthService service)
        {
            this.service = service;
            exceptionHnadler = new ExceptionHandler(Errors.ErrorDictionary);
            this._mapper = mapper;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestBodyDto model)
        {
            try
            {
                var result = await service.Login(model.Username, model.Password);
                return Ok(result);
            }
            catch (Exception exc)
            {
                return exceptionHnadler.Handle(exc);
            }
        }
    }
}
