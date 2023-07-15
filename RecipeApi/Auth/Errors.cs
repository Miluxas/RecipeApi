using RecipeApi.Common;
using RecipeApi.Exceptions;

namespace RecipeApi.Auth
{
    public static class Errors
    {
        public static readonly Dictionary<Type, ErrorObject> ErrorDictionary = new Dictionary<Type, ErrorObject>()
        {
            { typeof( NotFoundException), new ErrorObject(404,"User not found.") },
             { typeof( UnauthorizedAccessException), new ErrorObject(403,"Unauthorized.") }
        };
    }
}
