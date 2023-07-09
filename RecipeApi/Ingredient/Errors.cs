using RecipeApi.Common;

namespace RecipeApi.Ingredient
{
    public static class Errors
    {
        public static readonly Dictionary<Type, ErrorObject> ErrorDictionary = new Dictionary<Type, ErrorObject>()
        {
            { typeof( Exception), new ErrorObject(404,"ToDo not found.") }
        };
    }
}
