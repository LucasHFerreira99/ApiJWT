using ApiJWT.Data;
using ApiJWT.Dtos;
using ApiJWT.Models;
using ApiJWT.Services.SenhaService;


namespace ApiJWT.Services.AuthService
{
    public class AuthService : IAuthInterface
    {

        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;

        public AuthService(AppDbContext context, ISenhaInterface senhaInterface = null)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }

        public async Task<ResponseModel<UsuarioCriacaoDto>> Registrar(UsuarioCriacaoDto usuarioRegistro)
        {
            ResponseModel<UsuarioCriacaoDto> respostaServico = new ResponseModel<UsuarioCriacaoDto>();
            try
            {
                if(verificaSeEmailEUsuarioJaExiste(usuarioRegistro))
                {
                    respostaServico.Dados = null;
                    respostaServico.Mensagem = "Email/Usuario já cadastrados";
                    respostaServico.Status = false;
                    return respostaServico;
                }
                _senhaInterface.CriarSenhaHash(usuarioRegistro.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                UsuarioModel usuario = new UsuarioModel()
                {
                    Usuario = usuarioRegistro.Usuario,
                    Email = usuarioRegistro.Email,
                    Cargo = usuarioRegistro.Cargo,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                respostaServico.Mensagem = "Usuário criado com sucesso!";
            }catch (Exception ex)
            {
                respostaServico.Dados = null;
                respostaServico.Mensagem = ex.Message;
                respostaServico.Status = false;

            }
            return respostaServico;
        }

        public bool verificaSeEmailEUsuarioJaExiste(UsuarioCriacaoDto usuarioRegistro)
        {
            var usuario = _context.Usuarios.FirstOrDefault(userBanco => userBanco.Usuario == usuarioRegistro.Usuario || userBanco.Email == usuarioRegistro.Email);

            if (usuario != null) return true;

            return false;
        }





    }
}
