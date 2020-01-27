using MundoLibros.Models;
using MundoLibros.Service;
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
		public ListLib ()
		{
			InitializeComponent ();
		}
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //ViewLib l = new ViewLib();

            Libro libroActual = (Libro)e.Item;
            //Id.Text = Convert.ToString(libroActual.IdLibro);
            //NombreLibro.Text = libroActual.NombreLibro;
            //AutorLibro.Text = libroActual.AutorLibro;
            //FechaPublicacionLibro.Text = libroActual.FechaPublicacionLibro;
            //Precio.Text = Convert.ToString(libroActual.Precio);
            //Disponibildad.Text = Convert.ToString(libroActual.DisponibilidadLibro);
            //CodigoCat.Text = Convert.ToString(libroActual.IdCat);
            //await Navigation.PushAsync(new ViewLib(libroActual.NombreLibro));
        }
        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ViewLib());
        }
        
    }
}