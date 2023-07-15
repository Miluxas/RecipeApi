namespace RecipeApi.Auth.Models
{
    public record LogedInUserInfo
    {
        public string token { get; set; } = String.Empty;
        public DateTime expiration { get; set; }
    }
}
