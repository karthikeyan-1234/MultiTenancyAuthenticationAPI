using DemoAuthenticationAPI.Models;

namespace DemoAuthenticationAPI.Services
{
    public interface ITokenService
    {
        TokenData GetToken(string userName);
    }
}