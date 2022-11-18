using sca.Models.Request;
using sca.Models.Response;

namespace sca.Interfaces
{
    public interface IUserService
    {
        //Hacemos referencia donde se almacena el usuario y token
        UserResponse Auth(AuthRequest model);
    }
}
