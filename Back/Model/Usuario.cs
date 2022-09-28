using System;
using Microsoft.EntityFrameworkCore;
namespace Model;
public class Usuario
{
    public int id {get; set;}
    public string nome {get; set;}
    public string login {get; set;}
    public string senha {get; set;}
    public byte[] foto {get; set;}

    public int save(){
        using(var context = new Context()){
            var usuario = new Usuario(){
                id = this.id,
                nome = this.nome,
                login = this.login,
                senha = this.senha,
                foto = this.foto
            };
        }
        return 0;
    }
}
