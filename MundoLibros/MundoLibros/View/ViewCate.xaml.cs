using MundoLibros.Models;
using MundoLibros.Service;
using MundoLibros.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
        async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewLib());
        }


        private void Empty_Clicked(object sender, EventArgs e)
        {
            Descripcion.Text = "";
        }



        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Categoria miCategoria = (Categoria)e.SelectedItem;
            ListLib page = new ListLib(miCategoria);
            Navigation.PushAsync(page);
        }
    }
}