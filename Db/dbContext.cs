using System;
using Microsoft.EntityFrameworkCore;


public class Contexto : DbContext {

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\;Database=proyectos;Trusted_Connection=True");
    }

    public DbSet<Project> projects { get; set; }

    public DbSet<Task> tasks { get; set; }

    public DbSet<Material> materials { get; set; }

    public DbSet<materialConsume> materialConsumes { get; set; }


}