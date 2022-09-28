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
}
