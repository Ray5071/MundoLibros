using MundoLibros.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MundoLibros.Infrastructure
{
    public class InstanteLocator
    {
        public MainViewModel Main { get; set; }

        public InstanteLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
