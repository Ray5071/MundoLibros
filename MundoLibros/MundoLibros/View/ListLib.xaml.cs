using MundoLibros.Models;
using MundoLibros.Service;
using MundoLibros.ViewModel;
using SQLite;
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
        public int Id { get; set; }
        public ListLib (int Idd)
		{
            InitializeComponent();
            LibrosViewModel df = new LibrosViewModel();
            df.IdPrueba = Idd;
		}

    }
}