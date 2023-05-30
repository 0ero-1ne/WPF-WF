using Puzrain.Commands;
using Puzrain.DB;
using Puzrain.Model;
using Puzrain.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Puzrain.ViewModel
{
    public class CatalogViewModel : ViewModelBase
    {
        public readonly NavigationStore _navigationStore;
        public IEnumerable<Product> Products { get; set; }

        public ICommand OpenProduct { get; }

        public CatalogViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            Products = Repository.Repository.GetProducts();
            OpenProduct = new OpenProductCommand(_navigationStore, this);
        }
    }
}
