using System;
using System.Collections.Generic;
using System.Text;

namespace MundoLibros.Models
{
    public class Categoria
    {
        [SQLite.PrimaryKey]
        public int IdCat { get; set; }
        public string DescriptionCat { get; set; }
    }
}
