using MundoLibros.Models;
using MundoLibros.Service;
using MundoLibros.View;
using SQLite;
using System.Collections.Generic;
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

        private ObservableCollection<Categoria> _categoria;
        public ObservableCollection<Categoria> categoria { get => _categoria; set => this.SetValue(ref _categoria, value); }

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
        private string _selectedDispon;
        public string SelectedDispon
        {
            get { return _selectedDispon; }
            set { _selectedDispon = value; }
        }
        private int _idCat;
        public int IdCat
        {
            get { return _idCat; }
            set { _idCat = value; }
        }
        private Categoria _SelectedCategoria;
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
            categoria = new ObservableCollection<Categoria>(lista);
        }
        public IList<string> Dispon
        {
            get
            {
                return new List<string> { "Si", "No"};
            }
        }
        private async void LlenarLibros()
        {
            var lista = await _Data.ConsultarLibro();
            Libros = new ObservableCollection<Libro>(lista);
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
                DisponibilidadLibro = SelectedDispon,
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
                    DisponibilidadLibro = SelectedDispon,
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
                    DisponibilidadLibro = SelectedDispon,
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
            try
            {
                Libro libToUpdate = Libros.FirstOrDefault(l => l.IdLibro == IdLibro);
                libToUpdate.NombreLibro = NombreLibro;
                libToUpdate.AutorLibro = AutorLibro;
                libToUpdate.FechaPublicacionLibro = FechaPublicacionLibro;
                libToUpdate.PrecioLibro = PrecioLibro;
                libToUpdate.DisponibilidadLibro = SelectedDispon;
                libToUpdate.IdCat = SelectedCategoria.IdCat;

                using (var dat = DataBase.getInstance())
                {
                    await dat.UpdateLibro(libToUpdate);
                    LlenarLibros();
                    IsBusy = true;
                }
            }
            catch (System.Exception)
            {
                await App.Current.MainPage.DisplayAlert("ERROR!", "Algunos campos estan vacios", "Rellenar");
                await App.Current.MainPage.DisplayAlert("RECORDATORIO!", 
                    "Recuerde que tiene que ingresar nuevamente la Disponibilidad y la Categoria para editar su libro", "Aceptar");
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
