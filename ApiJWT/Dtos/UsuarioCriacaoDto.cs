using ApiJWT.Enum;
using System.ComponentModel.DataAnnotations;

namespace ApiJWT.Dtos
{
    public class UsuarioCriacaoDto
    {
        [Required(ErrorMessage = "O campo usuário é obrigatório")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório"), EmailAddress(ErrorMessage ="E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Senha { get; set; }
        [Compare("Senha", ErrorMessage ="Senhas não coincidem!")]
        public string ConfirmaSenha { get; set; }
        [Required(ErrorMessage = "O campo cargo é obrigatório")]
        public CargoEnum Cargo { get; set; }
    }
}
