using System;
using Microsoft.EntityFrameworkCore;

namespace Model;
public class Context : DbContext
{
    public DbSet<Usuario> Usuario {get; set;}
    public DbSet<M3u8> M3u8 {get; set;}
    public DbSet<Video> Video {get; set;}
    public DbSet<Historico> Historico {get; set;}
    public DbSet<Favoritos> Favoritos {get; set;}
    public DbSet<Curtidos> Curtidos {get; set;}
    public DbSet<AssistirMaisTarde> AssistirMaisTarde {get; set;}
    public DbSet<Recomendados> Recomendados {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

        optionsBuilder.UseSqlServer("Data Source=" + Environment.MachineName + ";Initial Catalog=VideoStreaming; Integrated Security=True");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>{
            entity.HasKey(u => u.id);
            entity.Property(u => u.nome).IsRequired();
            entity.Property(u => u.login).IsRequired();
            entity.Property(u => u.senha).IsRequired();
            entity.Property(u => u.foto);
        });

        modelBuilder.Entity<M3u8>(entity =>{
            entity.HasKey(m => m.id);
            entity.Property(m => m.m3u8Video).IsRequired();
        });

        modelBuilder.Entity<Historico>(entity =>{
            entity.HasKey(v => v.id);
            entity.Property(v => v.data).IsRequired();
            entity.HasOne(v => v.video);
            entity.HasOne(v => v.usuario);
        });

        modelBuilder.Entity<Favoritos>(entity =>{
            entity.HasKey(f => f.id);
            entity.Property(f => f.data).IsRequired();
            entity.HasOne(f => f.video);
            entity.HasOne(f => f.usuario);
        });
        
        modelBuilder.Entity<Curtidos>(entity =>{
            entity.HasKey(c => c.id);
            entity.Property(c => c.data).IsRequired();
            entity.HasOne(c => c.video);
            entity.HasOne(c => c.usuario);
        });

        modelBuilder.Entity<AssistirMaisTarde>(entity =>{
            entity.HasKey(a => a.id);
            entity.Property(a => a.data).IsRequired();
            entity.HasOne(a => a.video);
            entity.HasOne(a => a.usuario);
        });

        modelBuilder.Entity<Recomendados>(entity =>{
            entity.HasKey(r => r.id);
            entity.Property(r => r.data).IsRequired();
            entity.HasOne(r => r.video);
            entity.HasOne(r => r.usuario);
        });
    }
}
