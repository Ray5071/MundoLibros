using MundoLibros.Models;
using MundoLibros.Service;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MundoLibros.ViewModel
{
    public class CategoriaViewModel : BaseViewModel
    {
        private DataBase _Data;
        private Categoria _category;
        
        private ObservableCollection<Categoria> _categoria;
        public ObservableCollection<Categoria> categoria { get => _categoria; set => this.SetValue(ref _categoria, value); }

        public CategoriaViewModel()
        {
            _Data = new DataBase();
            LlenarCategorias();
        }

        #region Propiedades
        private int _idCat;
        public int IdCat
        {
            get { return _idCat; }
            set { _idCat = value; }
        }
        private string _descriptionCat;
        public string DescriptionCat
        {
            get { return _descriptionCat; }
            set { _descriptionCat = value; }
        }
        #endregion Propiedades

        public ObservableCollection<Categoria> List()
        {
            categoria.Add(new Categoria
            {
                IdCat = IdCat,
                DescriptionCat = DescriptionCat
            });
            return categoria;
        }
        private async void LlenarCategorias()
        {
            var lista = await _Data.ConsultarCategoria();
            categoria = new ObservableCollection<Categoria>(lista);
        }
        public ICommand AddCategory => new Command(AddCategoria);
        private async void AddCategoria()
        {
            if (categoria.Count == 0)
            {
                _category = new Categoria()
                {
                    IdCat = IdCat + 1,
                    DescriptionCat = DescriptionCat
                };
            }
            else
            {
                _category = new Categoria()
                {
                    DescriptionCat = DescriptionCat
                };
            }
            using (var dat = DataBase.getInstance())
            {
                await dat.InsertCat(_category);
                LlenarCategorias();
                IsBusy = true;
            }
        }
        public ICommand EditCategory => new Command(EditCategoria);
        private async void EditCategoria()
        {
            try
            {
                _category = new Categoria()
                {
                    IdCat = IdCat,
                    DescriptionCat = DescriptionCat
                };
                using (var dat = DataBase.getInstance())
                {
                    await dat.UpdateCategoria(_category);
                    LlenarCategorias();
                    IsBusy = true;
                }
            }
            catch(System.Exception)
            {
                await App.Current.MainPage.DisplayAlert("ERROR!", "No se ha especificado que Categoria sera Editada" +
                    "\nAlgunos campos pueden estar vacios.", "Especificar");
                await App.Current.MainPage.DisplayAlert("NOTA!", "Pulse la categoria a editar y cuando termine, vuelva a pulsar aqui", "Aceptar");
            }
        }
        public ICommand DeleteCategory => new Command(DeleteCategoria);
        private async void DeleteCategoria()
        {
            try
            {
                Categoria CatToDelete = categoria.FirstOrDefault(l => l.IdCat == IdCat);
                using (var dat = DataBase.getInstance())
                {
                    for (int i = 0; i < categoria.Count; i++)
                    {
                        if (categoria[i].IdCat == CatToDelete.IdCat)
                        {
                            categoria[i] = CatToDelete;
                            await dat.DeleteCategoria(CatToDelete);
                        }
                    }
                    LlenarCategorias();
                    IsBusy = true;
                }
            }
            catch (System.Exception)
            {
                await App.Current.MainPage.DisplayAlert("ERROR!", "No se ha especificado que Categoria sera Eliminada", "Especificar");
                await App.Current.MainPage.DisplayAlert("NOTA!", "Pulse la categoria a eliminar y vuelva a pulsar aqui", "Aceptar");
            }
        }

    }
}
