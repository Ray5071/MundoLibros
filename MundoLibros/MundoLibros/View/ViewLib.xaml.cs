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
            IdLib.Text = Convert.ToString(libroActual.IdLibro);
            NombreLibro.Text = libroActual.NombreLibro;
            AutorLibro.Text = libroActual.AutorLibro;
            FechaPublicacionLibro.Text = libroActual.FechaPublicacionLibro;
            PrecioLib.Text = Convert.ToString(libroActual.PrecioLibro);
        }
        private void Empty_Clicked(object sender, EventArgs e)
        {
            IdLib.Text = "";
            NombreLibro.Text = "";
            AutorLibro.Text = "";
            FechaPublicacionLibro.Text = "";
            PrecioLib.Text = "";
            myPickerDis.SelectedIndex = -1;
            myPicker.SelectedIndex = -1;
        }

        private void List_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            //await Navigation.PushAsync(new ListLib());
        }
    }
}