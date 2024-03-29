﻿using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Auth.DTOs
{

    public record LoginRequestBodyDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Username { get; set; } = String.Empty;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Password { get; set; } = String.Empty;
    }

}
