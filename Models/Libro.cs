using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bibliotecaEF.Models
{
    public class Libro
    {
        public Guid LibroId { get; set; }
        public Guid AutorId { get; set; }
        public string LibroNombre { get; set;}
        public string LibroDescripcion { get; set;}
        public NivelEstante UbicacionLibroEstante { get; set;}
        public DateTime FechaRegistro { get; set;}
        public string GeneroLibro { get; set; }
        public string Resumen { get; set; }

        //Variable para traer la informacion relacionada al autor en la consulta
        public virtual Autor Autor { get; set;}


    }

    public enum NivelEstante
    {
        Baja,
        Media,
        Alta
    }
}
