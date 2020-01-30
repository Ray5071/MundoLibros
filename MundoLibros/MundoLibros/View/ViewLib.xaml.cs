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
        public string Categor { get; set; }
        public ViewLib ()
		{
			InitializeComponent ();
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Libro libroActual = (Libro)e.Item;
            IdLib.Text = Convert.ToString(libroActual.IdLibro);
            NombreLibro.Text = libroActual.NombreLibro;
            AutorLibro.Text = libroActual.AutorLibro;
            FechaPublicacionLibro.Text = libroActual.FechaPublicacionLibro;
            PrecioLib.Text = Convert.ToString(libroActual.PrecioLibro);
            Dispo.Text = Convert.ToString(libroActual.DisponibilidadLibro);
            //CodigoCat.Text = Convert.ToString(libroActual.IdCat);

            //await db.QueryAsync<Libro>("select * from Libro where IdCat = ?", libroActual.IdCat);
        }
        private void Empty_Clicked(object sender, EventArgs e)
        {
            IdLib.Text = "";
            NombreLibro.Text = "";
            AutorLibro.Text = "";
            FechaPublicacionLibro.Text = "";
            PrecioLib.Text = "";
            Dispo.Text = "";
            myPicker.SelectedIndex = -1;
            //CodigoCat.Text = "";
        }
        private void ListVie_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //CategoriasViewModel CateActual = (CategoriasViewModel)e.Item;
            //CodigoCat.Text = Convert.ToString(CateActual.IdCat);
        }

        private void List_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            //await Navigation.PushAsync(new ListLib());
        }
    }
}