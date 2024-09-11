using System.ComponentModel.DataAnnotations;

namespace ApiJWT.Dtos
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "O campo E-mail é obrigatório"), EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
