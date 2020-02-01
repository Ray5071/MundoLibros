using MundoLibros.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MundoLibros.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewCate : ContentPage
	{
		public ViewCate()
		{
			InitializeComponent();
		}
        private void Empty_Clicked(object sender, EventArgs e)
        {
            Codigo.Text = "";
            Descripcion.Text = "";
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var con = await App.Current.MainPage.DisplayAlert("Pregunta!", 
                "Quiere Editar/Eliminar o ir a los libros de esta categoria?", "Editar/Eliminar", "Ir a lista");

            if (!con)
            {
                Categoria miCategoria = (Categoria)e.SelectedItem;
                ListLib page = new ListLib(miCategoria);
                await Navigation.PushAsync(page);
            }
            else
            {
                Descripcion.Focus();
                Categoria EditarCategory = (Categoria)e.SelectedItem;
                Codigo.Text = Convert.ToString(EditarCategory.IdCat);
                Descripcion.Text = EditarCategory.DescriptionCat;
            }
        }
    }
}