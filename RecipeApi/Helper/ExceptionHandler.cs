using Azure;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Common;

namespace RecipeApi.Helper
{
    public class ExceptionHandler
    {
        private readonly Dictionary<Type, ErrorObject> _errorDictionary;
        public ExceptionHandler(Dictionary<Type, ErrorObject> errorDictionary)
        {
            _errorDictionary = errorDictionary;
        }
        public ObjectResult Handle(Exception exception)
        {
            var result = _errorDictionary[exception.GetType()];
            if (result == null)
            {
                return new ObjectResult(new Response { Status = "Error", Message = exception.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
            return new ObjectResult(new Response { Status = "Error", Message = result.Message }) { StatusCode = result.StatusCode };
        }
    }
}
