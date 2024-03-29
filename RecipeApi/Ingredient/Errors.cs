﻿using RecipeApi.Common;
using RecipeApi.Exceptions;

namespace RecipeApi.Ingredient
{
    public static class Errors
    {
        public static readonly Dictionary<Type, ErrorObject> ErrorDictionary = new Dictionary<Type, ErrorObject>()
        {
            { typeof( NotFoundException), new ErrorObject(404,"Ingredient not found.") }
        };
    }
}
