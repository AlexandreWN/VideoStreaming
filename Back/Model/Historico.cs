using System;
using Microsoft.EntityFrameworkCore;
namespace Model;
public class Historico
{
    public int id {get; set;}
    public DateTime data {get; set;}   
    public Video video {get; set;}
    public Usuario usuario {get; set;}
    
    public int save(){
        using(var context = new Context()){
            var historico = new Historico(){

            };
        }
        return 0;
    }

    public static string deleteHistorico(int id){
        using(var context = new Context())
        {
            var historico = context.Historico.First(h=> h.id == id);
            context.RemoveRange(historico);  
            context.SaveChanges();
            return "foi";
        }
    }
}
