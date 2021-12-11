using api.Entity;

namespace api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
