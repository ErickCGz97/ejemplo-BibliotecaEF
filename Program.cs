using bibliotecaEF;
using bibliotecaEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Cadena de conexion para SLQ Server
builder.Services.AddSqlServer<LibrosContext>(builder.Configuration.GetConnectionString("cnBiblioteca"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Prueba de conexion a la base de datos
app.MapGet("/dbconexion", async ([FromServices] LibrosContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria " + dbContext.Database.IsInMemory());
});


// METODOS DE PRUEBA PARA AUTORES
//Mostrar datos
app.MapGet("/api/mostrarAutores", async ([FromServices] LibrosContext dbContext) =>
{
    return Results.Ok(dbContext.Autores);
});

//Agregar nuevo registro
app.MapPost("api/registrarAutor", async ([FromServices] LibrosContext dbContext, [FromBody] Autor autor) =>
{
    autor.AutorId = Guid.NewGuid();
    await dbContext.AddAsync(autor);

    await dbContext.SaveChangesAsync();

    return Results.Ok("Registro de nuevo autor ingresado exitosamente");
});

//Actualizar datos existentes
app.MapPut("api/actualizarAutor/{id}", async ([FromServices] LibrosContext dbContext, [FromBody] Autor autor, [FromRoute] Guid id) =>
{
    var autorActual = dbContext.Autores.Find(id);
    if (autorActual != null)
    {
        autorActual.AutorNombre = autor.AutorNombre;
        autorActual.AutorPais = autor.AutorPais;
        autorActual.AutorGenero = autor.AutorGenero;

        await dbContext.SaveChangesAsync();
        return Results.Ok("Datos de autor actualizados exitosamente");
    }
    return Results.NotFound("No se encontro el registro");
});

//Eliminar datos existentes
app.MapDelete("api/eliminarAutor/{id}", async ([FromServices] LibrosContext dbContext, [FromRoute] Guid id) =>
{
    var autorActual = dbContext.Autores.Find(id);

    if (autorActual != null)
    {
        dbContext.Remove(autorActual);

        await dbContext.SaveChangesAsync();
        return Results.Ok("Datos de autor eliminados exitosamente");
    }
    return Results.NotFound("No se encontro el registro");
});




// METODOS DE PRUEBA PARA LIBROS

//Mostrar datos
app.MapGet("/api/mostrarLibros", async ([FromServices] LibrosContext dbContext) =>
{
    return Results.Ok(dbContext.Libros);
});

//Agregar nuevo registro
app.MapPost("api/registrarLibro", async ([FromServices] LibrosContext dbContext, [FromBody] Libro libro) =>
{
    libro.LibroId = Guid.NewGuid();
    libro.FechaRegistro = DateTime.Now;
    await dbContext.AddAsync(libro);

    await dbContext.SaveChangesAsync();

    return Results.Ok("Registro de nuevo libro ingresado exitosamente");
});

//Actualizar datos existentes
app.MapPut("api/actualizarLibro/{id}", async ([FromServices] LibrosContext dbContext, [FromBody] Libro libro, [FromRoute] Guid id) =>
{
    var libroActual = dbContext.Libros.Find(id);
    if(libroActual != null)
    {
        libroActual.LibroNombre = libro.LibroNombre;
        libroActual.LibroDescripcion = libro.LibroDescripcion;
        libroActual.UbicacionLibroEstante = libro.UbicacionLibroEstante;
        libroActual.GeneroLibro = libro.GeneroLibro;
        libroActual.Resumen = libro.Resumen;

        await dbContext.SaveChangesAsync();
        return Results.Ok("Libro actualizado exitosamente");
    }
        return Results.NotFound("No se encontro el registro");
});

//Eliminar datos existentes
app.MapDelete("api/eliminarLibro/{id}", async ([FromServices] LibrosContext dbContext, [FromRoute] Guid id) =>
{
    var libroActual = dbContext.Libros.Find(id);

    if (libroActual != null)
    {
        dbContext.Remove(libroActual);

        await dbContext.SaveChangesAsync();
        return Results.Ok("Libro eliminado exitosamente");
    }
    return Results.NotFound("No se encontro el registro");
});

app.Run();


/*
 * Autor: Erick Cabrera
 * 
 * Proyecto: Biblioteca
 * Aprendizaje: Manejo de C# y ORM: Entity Framework
 * Versiones:
 *  .NET: 6.0
 *  Entity Framework Core: 6.0.3
 *  Entity Framework In Memory: 6.0.3
 *  Entity Framework SQL: 6.0.3 
 *  
 *  Visual Studio Comunity 2022
 *  SQL Server Management Studio 2019
 *  Postman API Platform
 *      Programa ejecutado haciendo uso de PowerShell incluida en Visual Studio
 *  
 * Fecha: 18/9/2023  
*/ 