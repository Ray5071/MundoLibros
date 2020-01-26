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
    }
}