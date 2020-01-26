using MundoLibros.Models;
using MundoLibros.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MundoLibros.ViewModel
{
    public class ListViewModel : BaseViewModel
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

        public ListViewModel()
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
    }
}
