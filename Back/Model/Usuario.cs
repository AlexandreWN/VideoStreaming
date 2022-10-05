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

     public static string deleteUsuario(string login){
         using(var context = new Context())
        {
            var historico = context.Historico.Where(e => e.usuario.login == login);
            var assistirMaisTarde = context.AssistirMaisTarde.Where(a => a.usuario.login == login);
            var curtidos = context.Curtidos.Where(c => c.usuario.login == login);
            var favoritos = context.Favoritos.Where(f => f.usuario.login == login);
            var recomendados = context.Recomendados.Where(r => r.usuario.login == login);

            foreach(var dados in historico){
                Historico.deleteHistorico(dados.id);
            }
            foreach(var dados in assistirMaisTarde){
                AssistirMaisTarde.deleteAssistirMaisTarde(dados.id);
            }
            foreach(var dados in curtidos){
                Curtidos.deleteCurtidos(dados.id);
            }
            foreach(var dados in favoritos){
                Favoritos.deleteFavoritos(dados.id);
            }
            foreach(var dados in recomendados){
                Recomendados.deleteRecomendados(dados.id);
            }
            
            var usuario = context.Usuario.FirstOrDefault(e=>e.login == login);
            context.Remove(usuario);  
            context.SaveChanges();
            return "foi";
        }
    }
}
