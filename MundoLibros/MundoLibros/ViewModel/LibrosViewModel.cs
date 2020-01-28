using MundoLibros.Models;
using MundoLibros.Service;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MundoLibros.ViewModel
{
    public class LibrosViewModel : BaseViewModel
    {
        private DataBase _Data;
        private Libro lib;
        private ObservableCollection<Libro> _libros;
        private ObservableCollection<Categoria> _categoria;
        private Categoria _SelectedCategoria;
        public ObservableCollection<Categoria> Types { get => _categoria; set => this.SetValue(ref _categoria, value); }
        public ObservableCollection<Libro> Libros { get => _libros; set => this.SetValue(ref _libros, value); }

        #region Propiedades
        private int _idLibro;
        public int IdLibro
        {
            get { return _idLibro; }
            set { _idLibro = value; }
        }
        private string _nombreLibro;
        public string NombreLibro
        {
            get { return _nombreLibro; }
            set { _nombreLibro = value; }
        }
        private string _autorLibro;
        public string AutorLibro
        {
            get { return _autorLibro; }
            set { _autorLibro = value; }
        }
        private string _fechaPublicacion;
        public string FechaPublicacionLibro
        {
            get { return _fechaPublicacion; }
            set { _fechaPublicacion = value; }
        }
        private string _precio;
        public string PrecioLibro
        {
            get { return _precio; }
            set { _precio = value; }
        }
        private string _disponibilidad;
        public string DisponibilidadLibro
        {
            get { return _disponibilidad; }
            set { _disponibilidad = value; }
        }
        private int _idCat;
        public int IdCat
        {
            get { return _idCat; }
            set { _idCat = value; }
        }
        public Categoria SelectedCategoria
        {
            get { return _SelectedCategoria; }
            set { _SelectedCategoria = value; }
        }
        #endregion Propiedades

        public LibrosViewModel()
        {
            _Data = new DataBase();
            LlenarLibros();
            LlenarCategorias();
        }
        public async void LlenarCategorias()
        {
            var lista = await _Data.ConsultarCategoria();
            this.Types = new ObservableCollection<Categoria>(lista);
        }
        //public IList<string> Categorias
        //{
        //    get
        //    {
        //        return new List<string> { "Historia", "Poesia", "Novela" };
        //    }
        //}

        private async void LlenarLibros()
        {
            var lista = await _Data.ConsultarLibro();
            this.Libros = new ObservableCollection<Libro>(lista);

            NombreLibro = "";
        }
        public ObservableCollection<Libro> List()
        {
            Libros.Add(new Libro
            {
                IdLibro = IdLibro,
                NombreLibro = NombreLibro,
                AutorLibro = AutorLibro,
                FechaPublicacionLibro = FechaPublicacionLibro,
                PrecioLibro = PrecioLibro,
                DisponibilidadLibro = DisponibilidadLibro,
                IdCat = SelectedCategoria.IdCat

            });
            return Libros;
        }
        public ICommand Agregar => new Command(AgregarLibro);
        private async void AgregarLibro()
        {
            if (_libros.Count == 0)
            {
                lib = new Libro()
                {
                    IdLibro = IdLibro + 1,
                    NombreLibro = NombreLibro,
                    AutorLibro = AutorLibro,
                    FechaPublicacionLibro = FechaPublicacionLibro,
                    PrecioLibro = PrecioLibro,
                    DisponibilidadLibro = DisponibilidadLibro,
                    IdCat = SelectedCategoria.IdCat
                };
            }
            else
            {
                lib = new Libro()
                {
                    NombreLibro = NombreLibro,
                    AutorLibro = AutorLibro,
                    FechaPublicacionLibro = FechaPublicacionLibro,
                    PrecioLibro = PrecioLibro,
                    DisponibilidadLibro = DisponibilidadLibro,
                    IdCat = SelectedCategoria.IdCat
                };
            }
            using (var dat = DataBase.getInstance())
            {
                await dat.InserLibro(lib);
                LlenarLibros();
                IsBusy = true;
            }
        }
        public ICommand Actualizar => new Command(ActualizarLibro);
        private async void ActualizarLibro()
        {
            Libro libToUpdate = Libros.FirstOrDefault(l => l.IdLibro == IdLibro);
            libToUpdate.NombreLibro = NombreLibro;
            libToUpdate.AutorLibro = AutorLibro;
            libToUpdate.FechaPublicacionLibro = FechaPublicacionLibro;
            libToUpdate.PrecioLibro = PrecioLibro;
            libToUpdate.DisponibilidadLibro = DisponibilidadLibro;
            libToUpdate.IdCat = SelectedCategoria.IdCat;

            using (var dat = DataBase.getInstance())
            {
                await dat.UpdateLibro(libToUpdate);
                LlenarLibros();
                IsBusy = true;
            }
        }
        public ICommand Eliminar => new Command(EliminarLibro);
        private async void EliminarLibro()
        {
            Libro libToDelete = Libros.FirstOrDefault(l => l.IdLibro == IdLibro);
            using (var dat = DataBase.getInstance())
            {
                for (int i = 0; i < Libros.Count; i++)
                {
                    if (Libros[i].IdLibro == libToDelete.IdLibro)
                    {
                        Libros[i] = libToDelete;
                        await dat.DeleteLibro(libToDelete);
                    }
                }
                LlenarLibros();
                IsBusy = true;
            }
        }
    }
}
