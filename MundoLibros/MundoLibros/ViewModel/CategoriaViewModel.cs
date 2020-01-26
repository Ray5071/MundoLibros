using Android.Icu.Text;
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
        private Categoria Type;
        private ObservableCollection<Categoria> _categoria;
        public ObservableCollection<Categoria> Types { get => _categoria; set => this.SetValue(ref _categoria, value); }

        public CategoriaViewModel()
        {
            _Data = new DataBase();
            LlenarCategorias();
        }
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
        private async void LlenarCategorias()
        {
            var lista = await _Data.ConsultarCategoria();
            this._categoria = new ObservableCollection<Categoria>(lista);

            DescriptionCat = "";
        }
        public ObservableCollection<Categoria> List()
        {
            Types.Add(new Categoria
            {
                IdCat = IdCat,
                DescriptionCat = DescriptionCat
            });
            return Types;
        }
        public ICommand Agregar => new Command(InsertCategoria);
        private async void InsertCategoria()
        {
            Type = new Categoria()
            {
                IdCat = IdCat,
                DescriptionCat = DescriptionCat
            };
            using (var dat = DataBase.getInstance())
            {
                await dat.InsertCat(Type);
                IsBusy = true;
            }
        }
        public ICommand Actualizar => new Command(ActualizarCategoria);
        private async void ActualizarCategoria()
        {
            using (var dat = DataBase.getInstance())
            {
                Categoria CatToUpdate = Types.FirstOrDefault(l => l.IdCat == IdCat);

                CatToUpdate.DescriptionCat = DescriptionCat;

                await dat.UpdateCategoria(CatToUpdate);
                LlenarCategorias();
                IsBusy = true;
            }
        }
    }
}
