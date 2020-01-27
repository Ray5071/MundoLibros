using MundoLibros.Models;
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
            await Navigation.PushAsync(new ViewLib(""));
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Categoria CateActual = (Categoria)e.Item;
            Codigo.Text = Convert.ToString(CateActual.IdCat);
            Descripcion.Text = CateActual.DescriptionCat;
        }
        private void Empty_Clicked(object sender, EventArgs e)
        {
            Descripcion.Text = "";
        }
        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListLib());
        }
    }
}