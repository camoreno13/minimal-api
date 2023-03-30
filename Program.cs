using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef.Context;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

// Add DataBase in memory
// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
// Add DataBase SQL --> se le pasa el string de conexion de la base de datos
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// FromService --> indica que se inyectara en tiempo de ejecucion
app.MapGet("/dbconnection", async ([FromServices] TareasContext dbContext) =>
{
    //usado para validar si la db esta creada y sino la crea
    dbContext.Database.EnsureCreated();
    //Retorna este mensaje y valor true/false si la base de datos esta en memoria
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    // trae toda la data de tareas
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});

app.MapPost("/api/addTarea", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    // dos formas de agregar
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/uTarea/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);
    if (tareaActual != null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

// app.MapGet("/dbconnectionsql", async ([FromServices] TareasContext dbContext) =>
// {
//     //usado para validar si la db esta creada y sino la crea
//     dbContext.Database.EnsureCreated();
//     //Retorna este mensaje y valor true/false si la base de datos esta en memoria
//     return Results.Ok("Base de datos sql server: " + dbContext.Database.IsInMemory());
// });

app.Run();
