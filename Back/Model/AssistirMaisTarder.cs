using System;
using Microsoft.EntityFrameworkCore;
namespace Model;
public class AssistirMaisTarde
{
    public int id {get; set;}
    public DateTime data {get; set;}
    public Video video {get; set;}
    public Usuario usuario {get; set;}
    
    public int save(){
        using(var context = new Context()){
            var assistirMaisTarde = new AssistirMaisTarde(){

            };
        }
        
        return 0;
    }
}
