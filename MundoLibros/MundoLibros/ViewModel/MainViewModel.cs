using System;
using System.Collections.Generic;
using System.Text;

namespace MundoLibros.ViewModel
{
    public class MainViewModel
    {
        private static MainViewModel instance;

        public MainViewModel()
        {
            instance = this;
        }
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}
