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
	public partial class PagePrincipal : MasterDetailPage
	{
		public PagePrincipal ()
		{
			InitializeComponent ();
            this.Master = new master();
            this.Detail = new NavigationPage(new details());

            App.MasterD = this;
		}
	}
}