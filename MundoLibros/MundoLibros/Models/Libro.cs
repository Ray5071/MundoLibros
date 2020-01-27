using System;
using System.Collections.Generic;
using System.Text;

namespace MundoLibros.Models
{
    public class Libro
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        [SQLite.Indexed]
        public int IdCat { get; set; }
        public string AutorLibro { get; set; }
        public string FechaPublicacionLibro { get; set; }
        public string PrecioLibro { get; set; }
        public string DisponibilidadLibro { get; set; }
    }
}
