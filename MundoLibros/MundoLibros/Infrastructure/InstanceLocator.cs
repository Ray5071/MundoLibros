using MundoLibros.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MundoLibros.Infrastructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
