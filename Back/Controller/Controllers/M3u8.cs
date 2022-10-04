using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using io = System.IO;

namespace Controller.Controllers;

using Model;

[ApiController]
[Route("[controller]")]
public class M3u8 : ControllerBase
{
    [HttpPost("teste")]
    public object teste()
    {
        var path = @"C:\Users\Aluno\Desktop\ProjetoAniStream\videoToStreamming\";
        Context context = new Context();

        string x = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Count().ToString();
        Console.WriteLine(x);

        for (int i = 0; i < int.Parse(x) - 1; i++)
        {
            var data = io.File.ReadAllBytes(path + $"Ronnie O'Sullivan Fastest 147{i}.ts");

            context.Contents.Add(new Content()
            {
                Bytes = data
            });
        }
        var m3u8 = io.File.ReadAllBytes(path + "Ronnie O'Sullivan Fastest 147.m3u8");
        context.Contents.Add(new Content()
        {
            Bytes = m3u8
        });
        context.SaveChanges();
        
        return "Foi";
    }

    [HttpGet("content/{id}")]
    [EnableCors("main")]
    public IActionResult getContent(int id)
    {
        Context context = new Context();
        var content = context.Contents
            .FirstOrDefault(c => c.Id == id);
        if (content == null)
            return NotFound();
        return File(content.Bytes, "application/octet-stream");
    }
}
