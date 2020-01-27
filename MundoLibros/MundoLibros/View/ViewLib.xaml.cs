using MundoLibros.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MundoLibros.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewLib : ContentPage
	{
        //private SQLiteAsyncConnection db;
        //private Categoria ca;
        public ViewLib ()
		{
			InitializeComponent ();
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Libro libroActual = (Libro)e.Item;
            Id.Text = Convert.ToString(libroActual.IdLibro);
            NombreLibro.Text = libroActual.NombreLibro;
            AutorLibro.Text = libroActual.AutorLibro;
            FechaPublicacionLibro.Text = libroActual.FechaPublicacionLibro;
            PrecioLib.Text = Convert.ToString(libroActual.PrecioLibro);
            Dispo.Text = Convert.ToString(libroActual.DisponibilidadLibro);
            CodigoCat.Text = Convert.ToString(libroActual.IdCat);

            //await db.QueryAsync<Libro>("select * from Libro where IdCat = ?", libroActual.IdCat);
        }
        private void Empty_Clicked(object sender, EventArgs e)
        {
            Id.Text = "";
            NombreLibro.Text = "";
            AutorLibro.Text = "";
            FechaPublicacionLibro.Text = "";
            PrecioLib.Text = "";
            Dispo.Text = "";
            CodigoCat.Text = "";
        }
        private void ListVie_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Categoria CateActual = (Categoria)e.Item;
            CodigoCat.Text = Convert.ToString(CateActual.IdCat);
        }
    }
}