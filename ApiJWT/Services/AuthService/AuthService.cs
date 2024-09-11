using ApiJWT.Data;
using ApiJWT.Dtos;
using ApiJWT.Models;
using ApiJWT.Services.SenhaService;
using Microsoft.EntityFrameworkCore;


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

        public async Task<ResponseModel<string>> Login(UsuarioLoginDto usuarioLogin)
        {
            ResponseModel<string> respostaServico = new ResponseModel<string>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(userBanco => userBanco.Email == usuarioLogin.Email);

                if(usuario == null)
                {
                    respostaServico.Mensagem = "Credenciais inválidas!";
                    respostaServico.Status = false;
                    return respostaServico;
                }

                if (!_senhaInterface.VerificaSenhaHash(usuarioLogin.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    respostaServico.Mensagem = "Credenciais inválidas!";
                    respostaServico.Status = false;
                    return respostaServico;
                }
                var token = _senhaInterface.CriarToken(usuario);

                respostaServico.Mensagem = "Usuario logado com sucesso!";
                respostaServico.Dados = token;

            }
            catch (Exception ex)
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
