using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using io = System.IO;
namespace Controller.Controllers;
using Model;

[ApiController]
[Route("[controller]")]
public class Usuario : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object resgisterUsuario([FromBody] Model.Usuario usuario){
        var id = usuario.save();
        if(id == -1){
            return "usuario ja cadastrado";
        }else{
            return new {
                id = usuario.id,
                nome = usuario.nome,
                login = usuario.login,
                senha = usuario.senha,
                foto = usuario.foto
            };
        }
    }
}