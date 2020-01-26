using MundoLibros.Models;
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
	public partial class ViewLib : ContentPage
	{
		public ViewLib ()
		{
			InitializeComponent ();
		}
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Libro libroActual = (Libro)e.Item;
            Id.Text = Convert.ToString(libroActual.IdLibro);
            NombreLibro.Text = libroActual.NombreLibro;
        }
        private void Empty_Clicked(object sender, EventArgs e)
        {
            NombreLibro.Text = "";
        }
    }
}