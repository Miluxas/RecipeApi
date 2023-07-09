namespace RecipeApi.Common
{
    public class ErrorObject
    {
        public ErrorObject(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }
        public ErrorObject(int statusCode)
        {
            this.StatusCode = statusCode;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
