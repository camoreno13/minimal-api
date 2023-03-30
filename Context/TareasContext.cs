using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef.Context;

public class TareasContext : DbContext
{
    // se especifica la base de datos llamada categorias de la clase tipo categoria 
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    // primero se obtienen los data annotation y se sobrescribe con fluent api 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // quiero hacer las restricciones para este model
        modelBuilder.Entity<Categoria>(categoria =>
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("8ed0cfd3-74af-4b87-9284-e87f209c892d"), Nombre = "Categoria 1", Peso = 10 });
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("f2674df3-6801-42b5-9338-ec35da6cd307"), Nombre = "Categoria 2", Peso = 20 });

            // normalizacion las tablas en singular
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId); // asignar la primary key
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150); // requerido y maxlength 150
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);

            categoria.HasData(categoriasInit);
        });




        modelBuilder.Entity<Tarea>(tarea =>
        {
            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("fb21f0db-e31b-4ed3-92fa-4687dcfcfdcf"), CategoriaId = Guid.Parse("8ed0cfd3-74af-4b87-9284-e87f209c892d") , Titulo = "Tarea 1 " , Descripcion = "tarea 1 " , PrioridadTarea = Prioridad.Baja , FechaCreacion = DateTime.Now});
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("7f1fc391-32a1-4f0a-9958-488ae5c0ae43"), CategoriaId = Guid.Parse("f2674df3-6801-42b5-9338-ec35da6cd307") , Titulo = "Tarea 2" , PrioridadTarea = Prioridad.Alta , FechaCreacion = DateTime.Now});

            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen); // ignorar el atributo para que no se cree en la base de datos

            tarea.HasData(tareasInit);
        });
    }
}