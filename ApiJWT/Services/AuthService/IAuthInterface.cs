using ApiJWT.Dtos;
using ApiJWT.Models;

namespace ApiJWT.Services.AuthService
{
    public interface IAuthInterface
    {
        Task<ResponseModel<UsuarioCriacaoDto>> Registrar(UsuarioCriacaoDto usuarioRegistro);
        Task<ResponseModel<string>> Login(UsuarioLoginDto usuarioLogin);
    }
}
