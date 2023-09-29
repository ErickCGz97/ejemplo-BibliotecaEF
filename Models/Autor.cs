using System.ComponentModel.DataAnnotations;

namespace bibliotecaEF.Models
{
    public class Autor
    {
        
        public Guid AutorId { get; set; }

        public string AutorNombre { get; set;}

        public string AutorPais { get; set;}

        public string AutorGenero { get; set;}

        //Variable para traer todos los libros y la informacion relacionada en la consulta
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
