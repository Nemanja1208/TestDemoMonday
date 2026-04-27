namespace ApplicationLayer
{
    public class JWTDto
    {
        public string Token { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;
    }
}