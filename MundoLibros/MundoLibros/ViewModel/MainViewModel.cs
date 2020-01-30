using System;
using System.Collections.Generic;
using System.Text;

namespace MundoLibros.ViewModel
{
    public class MainViewModel
    {
        private static MainViewModel instance;

        public CategoriaViewModel CatVM { get; set; }
        public LibrosViewModel LibroVM { get; set; }
        public ListViewModel LisVM { get; set; }
        public CategoriasViewModel Categoria { get; set; }

        public MainViewModel()
        {
            instance = this;
        }
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}
