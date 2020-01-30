using MundoLibros.Models;
using MundoLibros.Service;
using MundoLibros.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MundoLibros.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListLib : ContentPage
	{
        Categoria _categoria = null;
        DataBase df = new DataBase();
        LibrosViewModel fd = new LibrosViewModel();
        public ListLib ()
		{
            InitializeComponent();
        }
        public ListLib(Categoria categoria)
        {
            this._categoria = categoria;
        }
        protected async override void OnAppearing()
        {
            List<Libro> misLibros =
            await df.ConsultarLibro(_categoria.IdCat);

            this.listView.ItemsSource = misLibros;
            df.
        }
    }
}