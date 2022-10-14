using System;
using Microsoft.EntityFrameworkCore;
namespace Model;
public class Favoritos
{
    public int id {get; set;}
    public DateTime data {get; set;}
    public Video video {get; set;}
    public Usuario usuario {get; set;}
    
    public int save(){
        using(var context = new Context()){
            var favoritos = new Favoritos(){

            };
        }
        return 0;
    }

     public static string deleteFavoritos(int id){
        using(var context = new Context())
        {
            var favoritos = context.Favoritos.First(h=> h.id == id);
            context.Remove(favoritos);  
            context.SaveChanges();
            return "foi";
        }
    }
}
