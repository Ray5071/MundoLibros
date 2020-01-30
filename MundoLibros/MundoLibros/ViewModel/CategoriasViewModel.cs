using MundoLibros.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MundoLibros.ViewModel
{
    public class CategoriasViewModel : Categoria, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SQLiteAsyncConnection db;
        private ObservableCollection<CategoriasViewModel> _cate;
        public ObservableCollection<CategoriasViewModel> Cate { get => _cate; set => SetValue(ref _cate, value); }

        private ICommand Lista => new Command(ListaCate);
        public async void ListaCate()
        {
            await db.Table<Categoria>().ToListAsync();
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }
            backingField = value;
            OnPropertyChanged(propertyName);
        }
    }
}
