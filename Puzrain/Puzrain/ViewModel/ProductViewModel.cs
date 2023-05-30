using Puzrain.Model;
using Puzrain.Commands;
using Puzrain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Puzrain.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        public Product Product { get; }
        private readonly NavigationStore _navigationStore;

        public ICommand? RemoveProduct { get; }
        public ICommand? OpenEditProduct { get; }

        public ProductViewModel(Product product, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            Product = product;

            RemoveProduct = new RemoveProductCommand(_navigationStore, Product);
            OpenEditProduct = new OpenEditProductCommand(_navigationStore, Product);
        }

    }
}
