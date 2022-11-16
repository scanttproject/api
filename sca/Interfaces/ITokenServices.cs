using sca.Models;

namespace sca.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string key, Usuarios user);
        bool ValidateToken(string key, string token);
    }
}