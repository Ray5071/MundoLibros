using MundoLibros.Models;
using MundoLibros.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MundoLibros.ViewModel
{
    public class LibrosViewModel : BaseViewModel
    {
        #region PROPERTY
        private DataBase _Data;
        private Libro lib;
        private ObservableCollection<Libro> _libros;
        public ObservableCollection<Libro> Libros { get => _libros; set => this.SetValue(ref _libros, value); }

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
        
        #endregion PROPERTY

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
                };
            }
            else
            {
                lib = new Libro()
                {
                    NombreLibro = NombreLibro,
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
            using (var dat = DataBase.getInstance())
            {
                Libro libToUpdate = Libros.FirstOrDefault(l => l.IdLibro == IdLibro);

                libToUpdate.NombreLibro = NombreLibro;
                //libToUpdate.SintaxisLibro = SintaxisLibro;
                //libToUpdate.EditorialLibro = EditorialLibro;

                await dat.UpdateLibro(libToUpdate);
                LlenarLibros();
                IsBusy = true;
            }
        }
        public ICommand Eliminar => new Command(EliminarLibro);
        private async void EliminarLibro()
        {
            lib = new Libro()
            {
                IdLibro = IdLibro
            };
            using (var dat = DataBase.getInstance())
            {
                for (int i = 0; i < Libros.Count; i++)
                {
                    if (Libros[i].IdLibro == lib.IdLibro)
                    {
                        Libros[i] = lib;
                        await dat.DeleteLibro(lib);
                    }
                }
                LlenarLibros();
                IsBusy = true;
            }
        }
    }
}
