using MundoLibros.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MundoLibros.Service
{
    public class DataBase : IDisposable
    {
        private SQLiteAsyncConnection db;
        private static DataBase _data;
        //public ObservableCollection<Categoria> cat { get; set; }

        public static DataBase getInstance()
        {
            if (_data == null)
            {
                _data = new DataBase();
            }
            return _data;
        }
        public DataBase()
        {
            var platform = DependencyService.Get<IConfig>();
            db = platform.GetConnectionAsync();
            db.CreateTableAsync<Categoria>().Wait();
            db.CreateTableAsync<Libro>().Wait();
        }

        #region Categoria
        public async Task InsertCat(Categoria Cat)
        {
            Categoria _cat = await db.Table<Categoria>().OrderByDescending(u => u.IdCat).FirstOrDefaultAsync();
            if (_cat != null) { Cat.IdCat = _cat.IdCat + 1; }
            try
            {
                if (Cat.DescriptionCat == "")
                {
                    await App.Current.MainPage.DisplayAlert("Error!",
                        "Al parecer aun faltan datos...", "Corregir");
                }
                else
                {
                    await db.InsertAsync(Cat);
                    await App.Current.MainPage.DisplayAlert("Confirmacion!", "Categoria Insertada Correctamente", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERROR!", ex.Message, "Continuar");
            }
        }
        public async Task UpdateCategoria(Categoria Catego)
        {
            var con = await App.Current.MainPage.DisplayAlert("Actualizacion", "Seguro que desea Modificar este registro?", "Modificar", "Cancelar");
            if (!con) { return; }
            else
            {
                await db.UpdateAsync(Catego);
                await App.Current.MainPage.DisplayAlert("Actualizacion", "Libro Modificado correctamente", "Aceptar");
            }
        }
        public async Task<List<Categoria>> ConsultarCategoria()
        {
            return await db.Table<Categoria>().ToListAsync();
        }
        #endregion Categoria

        #region Libros
        public async Task InserLibro(Libro libro)
        {
            Libro lis = await db.Table<Libro>().OrderByDescending(u => u.IdLibro).FirstOrDefaultAsync();
            if (lis != null) { libro.IdLibro = lis.IdLibro + 1; }

            try
            {
                if (libro.NombreLibro == "")
                {
                    await App.Current.MainPage.DisplayAlert("Error!",
                        "Al parecer aun faltan datos...\n\nTitulo?\nSintaxis?\nEditorial?", "Corregir");
                }
                else
                {
                    await db.InsertAsync(libro);
                    await App.Current.MainPage.DisplayAlert("Confirmacion!", "Libro Insertado Correctamente", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Confirmacion!", ex.Message, "Continuar");
            }
        }
        public async Task UpdateLibro(Libro libro)
        {
            var con = await App.Current.MainPage.DisplayAlert("Actualizacion", "Seguro que desea Modificar este registro?", "Modificar", "Cancelar");
            if (!con) { return; }
            else
            {
                await db.UpdateAsync(libro);
                await App.Current.MainPage.DisplayAlert("Actualizacion", "Libro Modificado correctamente", "Aceptar");
            }
        }
        public async Task DeleteLibro(Libro libro)
        {
            var con = await App.Current.MainPage.DisplayAlert("Elimincacion", "Seguro que desea eliminar?", "Eliminar", "Cancelar");
            if (!con) { return; }
            else
            {
                await db.DeleteAsync(libro);
                await App.Current.MainPage.DisplayAlert("Elimincacion", "Libro Eliminado correctamente", "Aceptar");
            }
        }
        public async Task<Libro> ConsultarLibro(int Id)
        {
            return await db.Table<Libro>().FirstOrDefaultAsync(c => c.IdLibro == Id);
        }
        public async Task<List<Libro>> ConsultarLibro()
        {
            return await db.Table<Libro>().ToListAsync();
        }
        #endregion Libros
        public void Dispose()
        {
            
        }
    }
}
