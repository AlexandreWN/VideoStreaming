using System;
using Microsoft.EntityFrameworkCore;
namespace Model;
public class Video
{
    public int id {get; set;}
    public string nome {get; set;}
    public DateTime data {get; set;}
    public byte[] foto {get; set;}
    public M3u8 m3u8Id {get; set;}

    public int save(){
        using(var context = new Context()){
            var video = new Video(){

            };
        }
        return 0;
    }
}
