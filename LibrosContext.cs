using bibliotecaEF.Models;
using Microsoft.EntityFrameworkCore;

namespace bibliotecaEF
{
    public class LibrosContext : DbContext
    {
        //Representacion de tablas en Entity Framework
        //Creacion de tablas (colecciones)
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        //Constructor
        public LibrosContext(DbContextOptions<LibrosContext> options) : base(options) { }

        //Configurando el modelo Autor y Libro con Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Creacion de datos iniciales de autores - Prueba
            List<Autor> autorDatos = new List<Autor>();
            autorDatos.Add(new Autor() 
            {
                AutorId = Guid.Parse("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e46"), 
                AutorNombre = "George RR Martin",
                AutorPais = "Estados Unidos", 
                AutorGenero = "Masculino"
            });
            autorDatos.Add(new Autor()
            {
                AutorId = Guid.Parse("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e50"), 
                AutorNombre = "JRR Tolkien",
                AutorPais = "Inglaterra", 
                AutorGenero = "Masculino"
            });
            autorDatos.Add(new Autor()
            {
                AutorId = Guid.Parse("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e54"), 
                AutorNombre = "David Gill", 
                AutorPais = "España", 
                AutorGenero = "Masculino"
            });
            //

            modelBuilder.Entity<Autor>(autor => 
            {
                autor.ToTable("Autor");
                autor.HasKey(p => p.AutorId);
                autor.Property(p => p.AutorNombre).IsRequired().HasMaxLength(150);
                autor.Property(p => p.AutorPais);
                autor.Property(p => p.AutorGenero);

                //Registro de datos de prueba
                autor.HasData(autorDatos);
            });



            //Creacion de datos iniciales de libros - Prueba
            List<Libro> libroDatos = new List<Libro>();
            libroDatos.Add(new Libro() 
            {
                LibroId = Guid.Parse("65344f60-bcf3-49a0-be7c-354155c12333"), 
                AutorId = Guid.Parse("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e46"), 
                LibroNombre = "Juego de Tronos",
                LibroDescripcion = "Historia epica de Fantasia Medieval",
                UbicacionLibroEstante = NivelEstante.Media,
                FechaRegistro = DateTime.Now,
                Resumen = "En el pais de Westeros, diversas familias nobles luchan por el poder y por saber quien se quedara con el Trono de Hierro",
                GeneroLibro = "Novela - Literatura fantastica"
            });
            libroDatos.Add(new Libro()
            {
                LibroId = Guid.Parse("65344f60-bcf3-49a0-be7c-354155c12336"),
                AutorId = Guid.Parse("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e46"),
                LibroNombre = "Choque de Reyes",
                LibroDescripcion = "Historia epica de Fantasia Medieval",
                UbicacionLibroEstante = NivelEstante.Alta,
                FechaRegistro = DateTime.Now,
                Resumen = "La lucha por el trono de hierro continua en una guerra declarada entre familias nobles",
                GeneroLibro = "Novela - Literatura fantastica"
            });
            libroDatos.Add(new Libro()
            {
                LibroId = Guid.Parse("65344f60-bcf3-49a0-be7c-354155c12339"),
                AutorId = Guid.Parse("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e50"),
                LibroNombre = "El señor de los anillos - Las Dos Torres",
                LibroDescripcion = "Historia de fantasia heroica",
                UbicacionLibroEstante = NivelEstante.Baja,
                FechaRegistro = DateTime.Now,
                Resumen = "Frodo y Sam continuan su viaje hacia Mordor con el objetivo de destruir el anillo unico",
                GeneroLibro = "Novela - Fantasia Heroica"
            });
            libroDatos.Add(new Libro()
            {
                LibroId = Guid.Parse("65344f60-bcf3-49a0-be7c-354155c12342"),
                AutorId = Guid.Parse("7b86cea0-42c1-4b24-a9f2-b14ab4ff6e54"),
                LibroNombre = "El guerrero a la sombra del cerezo",
                LibroDescripcion = "Historia epica samurai",
                UbicacionLibroEstante = NivelEstante.Baja,
                FechaRegistro = DateTime.Now,
                Resumen = "Seizo Ikeda busca venganza por el exterminio de su clan y su familia",
                GeneroLibro = "Novela - Historia epica"
            });



            modelBuilder.Entity<Libro>(libro =>
            {
                libro.ToTable("Libro");
                libro.HasKey(p => p.LibroId);
                libro.HasOne(p =>  p.Autor).WithMany(p => p.Libros).HasForeignKey(p => p.AutorId);
                libro.Property(p => p.LibroNombre).IsRequired().HasMaxLength(200);
                libro.Property(p => p.LibroDescripcion);
                libro.Property(p => p.UbicacionLibroEstante);
                libro.Property(p => p.FechaRegistro);
                libro.Property(p => p.GeneroLibro);
                libro.Property(p => p.Resumen);

                //Registro de datos de prueba
                libro.HasData(libroDatos);
            });
        }
    }
}
