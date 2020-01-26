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
        public ObservableCollection<Categoria> List()
        {
            Types.Add(new Categoria
            {
                IdCat = IdCat,
                DescriptionCat = DescriptionCat
            });
            return Types;
        }
        private async void LlenarCategorias()
        {
            var lista = await _Data.ConsultarCategoria();
            this.Types = new ObservableCollection<Categoria>(lista);

            DescriptionCat = "";
        }
        public ICommand Agregar => new Command(InsertCategoria);
        private async void InsertCategoria()
        {
            if (Types.Count == 0)
            {
                Type = new Categoria()
                {
                    IdCat = IdCat + 1,
                    DescriptionCat = DescriptionCat
                };
            }
            else
            {
                Type = new Categoria()
                {
                    DescriptionCat = DescriptionCat
                };
            }
            using (var dat = DataBase.getInstance())
            {
                await dat.InsertCat(Type);
                LlenarCategorias();
                IsBusy = true;
            }
        }
        public ICommand Actualizar => new Command(ActualizarCategoria);
        private async void ActualizarCategoria()
        {
            Categoria CatToUpdate = Types.FirstOrDefault(l => l.IdCat == IdCat);
            CatToUpdate.DescriptionCat = DescriptionCat;

            using (var dat = DataBase.getInstance())
            {
                await dat.UpdateCategoria(CatToUpdate);
                LlenarCategorias();
                IsBusy = true;
            }
        }
        public ICommand Eliminar => new Command(EliminarLibro);
        private async void EliminarLibro()
        {
            Categoria CatToDelete = Types.FirstOrDefault(l => l.IdCat == IdCat);
            using (var dat = DataBase.getInstance())
            {
                for (int i = 0; i < Types.Count; i++)
                {
                    if (Types[i].IdCat == CatToDelete.IdCat)
                    {
                        Types[i] = CatToDelete;
                        await dat.DeleteCategoria(CatToDelete);
                    }
                }
                LlenarCategorias();
                IsBusy = true;
            }
        }
    }
}
