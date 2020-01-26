using MundoLibros.Models;
using MundoLibros.Service;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MundoLibros.ViewModel
{
    public class LibrosViewModel : BaseViewModel
    {
        private DataBase _Data;
        private Libro lib;
        private ObservableCollection<Libro> _libros;
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
        private decimal _precio;
        public decimal PrecioLibro
        {
            get { return _precio; }
            set { _precio = value; }
        }
        private bool _disponibilidad;
        public bool Disponibilidad
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
        #endregion Propiedades

        public LibrosViewModel()
        {
            _Data = new DataBase();
            LlenarLibros();
        }
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
                Precio = PrecioLibro, 
                DisponibilidadLibro = Disponibilidad, 
                IdCat = IdCat

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
                    Precio = PrecioLibro,
                    DisponibilidadLibro = Disponibilidad,
                    IdCat = IdCat
                };
            }
            else
            {
                lib = new Libro()
                {
                    NombreLibro = NombreLibro,
                    AutorLibro = AutorLibro,
                    FechaPublicacionLibro = FechaPublicacionLibro,
                    Precio = PrecioLibro,
                    DisponibilidadLibro = Disponibilidad,
                    IdCat = IdCat
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
            libToUpdate.Precio = PrecioLibro;
            libToUpdate.DisponibilidadLibro = Disponibilidad;
            libToUpdate.IdCat = IdCat;

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
