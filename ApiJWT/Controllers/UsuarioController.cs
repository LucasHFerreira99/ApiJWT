using ApiJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult<ResponseModel<string>> GetUsuario()
        {
            ResponseModel<string> response = new ResponseModel<string>();
            response.Mensagem = "Acessei";

            return Ok(response);
        }
    }
}
