using MundoLibros.Service;
using MundoLibros.View;
using MundoLibros.ViewModel;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MundoLibros
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterD { get; set; }
        public App()
        {
            InitializeComponent();

            var Main = MainViewModel.GetInstance();

            Main.LibroVM = new LibrosViewModel();
            Main.CatVM = new CategoriaViewModel();
            Main.LisVM = new ListViewModel();

            MainPage = new PagePrincipal();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
