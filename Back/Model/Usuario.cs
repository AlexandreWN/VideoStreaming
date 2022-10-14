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

    public static string deleteUsuarios(string login, string senha){
        using(var context = new Context())
        {
            var historico = context.Historico.Where(e => e.usuario.login == login && e.usuario.senha == senha);
            var assistirMaisTarde = context.AssistirMaisTarde.Where(a => a.usuario.login == login && a.usuario.senha == senha);
            var curtidos = context.Curtidos.Where(c => c.usuario.login == login && c.usuario.senha == senha);
            var favoritos = context.Favoritos.Where(f => f.usuario.login == login && f.usuario.senha == senha);
            var recomendados = context.Recomendados.Where(r => r.usuario.login == login && r.usuario.senha == senha);
            var usuario = context.Usuario.First(e=>e.login == login);
            context.Remove(usuario);
            context.SaveChanges();
            return "foi";
        }
    }
}
