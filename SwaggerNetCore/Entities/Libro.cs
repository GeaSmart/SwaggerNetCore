using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2307.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; } //propiedad de navegación
    }
}
