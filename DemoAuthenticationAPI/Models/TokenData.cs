namespace DemoAuthenticationAPI.Models
{
    public class TokenData
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
