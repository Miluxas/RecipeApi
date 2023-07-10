using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Recipe.DTOs
{
    public record AddRateRequestBodyDto
    {
        [Required]
        public int Value { get; set; }
    }

}
