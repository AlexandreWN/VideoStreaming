using System;
using Microsoft.EntityFrameworkCore;
namespace Model;

public class M3u8
{
    public int id {get; set;}
    public byte[] m3u8Video {get; set;}

    public int save(){
        using(var context = new Context()){
            var m3u8 = new M3u8(){
                id = this.id,
                m3u8Video = this.m3u8Video
            };
        }
        return 0;
    }
}

