using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2307.Entities
{
    public class Autor
    {
        /// <summary>
        /// Este es el identificador de un autor
        /// </summary>
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; } //propiedad de navegación
    }
}
