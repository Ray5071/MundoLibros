using MundoLibros.Models;
using MundoLibros.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MundoLibros.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListLib : ContentPage
	{
        Categoria _categoria;
        DataBase _Data;
        public ListLib ()
		{
            InitializeComponent();
        }
        public ListLib(Categoria categoria)
        {
            InitializeComponent();
            _categoria = categoria;
            _Data = new DataBase();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var misLibros = await _Data.ConsultarLibro(_categoria.IdCat);
            librosListview.ItemsSource = misLibros;
        }
    }
}